using UnityEngine;
using UnityEngine.UI;

public class SandBoxModeShow : MonoBehaviour
{
    public Button SandboxModeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       checkSandBoxMode();
    }

    public void checkSandBoxMode()
    {
        int progress = PlayerPrefs.GetInt("Progress");
        if (progress < 33)
        {
            SandboxModeButton.gameObject.SetActive(false);
        }
        else
        {
            SandboxModeButton.gameObject.SetActive(true);
        }
    }
}
