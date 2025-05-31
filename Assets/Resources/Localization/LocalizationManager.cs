using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;
    private Dictionary<string, string> localizedTexts;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(LoadLocalization("es")); // Importante: ahora es una corrutina
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator LoadLocalization(string languageCode)
    {
        string fileName = languageCode + ".json";
        string path = Path.Combine(Application.streamingAssetsPath, fileName);

        string json = null;

#if UNITY_ANDROID && !UNITY_EDITOR
        UnityWebRequest www = UnityWebRequest.Get(path);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al cargar localización: " + www.error);
            yield break;
        }

        json = www.downloadHandler.text;
#else
        if (File.Exists(path))
        {
            json = File.ReadAllText(path);
        }
        else
        {
            Debug.LogError("Archivo de localización no encontrado: " + path);
            yield break;
        }
#endif

        LocalizationEntry[] entries = JsonHelper.FromJson<LocalizationEntry>(json);
        localizedTexts = new Dictionary<string, string>();

        foreach (var entry in entries)
        {
            localizedTexts[entry.key] = entry.value;
        }

        Debug.Log("Localización cargada con éxito.");
    }

    public string GetText(string key)
    {
        if (localizedTexts != null && localizedTexts.TryGetValue(key, out var value))
        {
            return value;
        }
        return $"[Missing: {key}]";
    }
}
