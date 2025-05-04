using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
            LoadLocalization("es");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLocalization(string languageCode)
    {
        string path = Path.Combine(Application.streamingAssetsPath, languageCode + ".json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            LocalizationEntry[] entries = JsonHelper.FromJson<LocalizationEntry>(json);

            localizedTexts = new Dictionary<string, string>();
            foreach (var entry in entries)
            {
                localizedTexts[entry.key] = entry.value;
            }

            Debug.Log("Claves cargadas: " + localizedTexts.Count);
        }
        else
        {
            Debug.LogError("Archivo de localización no encontrado: " + path);
        }
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
