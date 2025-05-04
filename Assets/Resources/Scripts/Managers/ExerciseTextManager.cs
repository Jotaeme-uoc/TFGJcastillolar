using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExcerciseTextManager : MonoBehaviour
{
    public TextMeshProUGUI checkHomeText;
    public TextMeshProUGUI buttonYes;
    public TextMeshProUGUI buttonNo;
    ITheorySceneConfig sceneConfig;
    int currentPage = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneConfig = (ITheorySceneConfig)SceneConfigLoader.Load(SceneManager.GetActiveScene().buildIndex);
        checkHomeText.text = LocalizationManager.Instance.GetText("Check_Home");
        buttonYes.text = LocalizationManager.Instance.GetText("Button_Yes");
        buttonNo.text = LocalizationManager.Instance.GetText("Button_No");
    }
}
