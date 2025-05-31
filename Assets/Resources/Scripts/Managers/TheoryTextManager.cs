using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheoryTextManager : MonoBehaviour
{
    public TextMeshProUGUI titleContent;
    public TextMeshProUGUI theoryContent;
    public TextMeshProUGUI buttonForwardContent;
    public TextMeshProUGUI buttonBackwardContent;
    public TextMeshProUGUI checkHomeText;
    public TextMeshProUGUI buttonYes;
    public TextMeshProUGUI buttonNo;
    public GameObject image;
    ITheorySceneConfig sceneConfig;
    int currentPage = 0;
    
    void Start()
    {
        checkHomeText.text = getText("Check_Home");
        buttonYes.text = getText("Button_Yes");
        buttonNo.text = getText("Button_No");
        sceneConfig = (ITheorySceneConfig)SceneConfigLoader.Load(SceneManager.GetActiveScene().buildIndex);
        titleContent.text = getText($"{sceneConfig.TitleText[0]}");
        theoryContent.text = getText($"{sceneConfig.TheoryText[0]}");
        buttonForwardContent.text = getText("Button_Next");
        buttonBackwardContent.text = getText("Button_Previous");
        LoadImage(currentPage);
    }

    //Comprueba si existe una imagen asociada a la pagina actual, y activa o desactiva el objeto de la imagen segun corresponda
    private void LoadImage(int currentPage)
    {
        string imagePath = sceneConfig.imagesPaths[currentPage];
        Debug.Log($"Image path: {imagePath}");
        if (string.IsNullOrEmpty(imagePath))
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePath);
        }
    }

    public void Next()
    {
        currentPage++;
        if (currentPage < sceneConfig.numPages)
        {
            titleContent.text = getText($"{sceneConfig.TitleText[currentPage]}");
            theoryContent.text = getText($"{sceneConfig.TheoryText[currentPage]}");
            LoadImage(currentPage);
        }
        else
        {
            currentPage--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            return;            
        }
    }

    public void Previous()
    {
        if (currentPage > 0)
        {
            currentPage--;
            titleContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TitleText[currentPage]}");
            theoryContent.text = LocalizationManager.Instance.GetText($"{sceneConfig.TheoryText[currentPage]}");
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>($"{sceneConfig.imagesPaths[currentPage]}");
            LoadImage(currentPage);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            return;
        }
    }

    public string getText(string key)
    {
        return LocalizationManager.Instance.GetText(key);
    }


}
