using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenTextManager : MonoBehaviour
{

    public TextMeshProUGUI lessons;
    public TextMeshProUGUI options;
    public TextMeshProUGUI resetProgress;
    public TextMeshProUGUI unlockProgress;
    public Button SandboxModeButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lessons.text = getText("Lessons");
        options.text = getText("Options");
        resetProgress.text = getText("Reset_Progress");
        unlockProgress.text = getText("Unlock_Progress");
        SandboxModeButton.GetComponentInChildren<TextMeshProUGUI>().text = getText("SandBox_Mode");
    }

    private string getText(string key)
    {
        return LocalizationManager.Instance.GetText(key);
    }
}
