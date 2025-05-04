using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheoryTextManager : MonoBehaviour
{
    public TextMeshProUGUI titleContent;
    public TextMeshProUGUI theoryContent;
    public TextMeshProUGUI buttonForwardContent;
    public TextMeshProUGUI buttonBackwardContent;
    ITheorySceneConfig sceneConfig;
    int currentPage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneConfig = (ITheorySceneConfig)SceneConfigLoader.Load(SceneManager.GetActiveScene().buildIndex);
        titleContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TitleText[0]}");
        theoryContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TheoryText[0]}");
        buttonForwardContent.text = LocalizationManager.Instance.GetText("Button_Next");
        buttonBackwardContent.text = LocalizationManager.Instance.GetText("Button_Previous");
    }

    public void Next()
    {
        currentPage++;
        if (currentPage < sceneConfig.numPages)
        {
            titleContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TitleText[currentPage]}");
            theoryContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TheoryText[currentPage]}");
        }
        else
        {
            currentPage--;
            return;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Previous()
    {
        if (currentPage > 0)
        {
            currentPage--;
            titleContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TitleText[currentPage]}");
            theoryContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TheoryText[currentPage]}");
        }
        else
        {
            return;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


}
