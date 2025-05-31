using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionMenuTextManager : MonoBehaviour
{
    private GameObject[] selectionMenuTextObjects;
    public TextMeshProUGUI checkHomeText;
    public TextMeshProUGUI buttonYes;
    public TextMeshProUGUI buttonNo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkHomeText.text = getText("Check_Home");
        buttonYes.text = getText("Button_Yes");
        buttonNo.text = getText("Button_No");
        selectionMenuTextObjects = GameObject.FindGameObjectsWithTag("ProgressObject");
        foreach (GameObject progressObject in selectionMenuTextObjects)
        {
            string lessonName = progressObject.GetComponent<LessonSelect>().lessonName;
            Image unit = progressObject.GetComponent<Image>();
            Button lesson = progressObject.GetComponent<Button>();
            if(unit != null)
            {
                TextMeshProUGUI title = progressObject.GetComponentInChildren<TextMeshProUGUI>();
                title.text = getText(lessonName);
            }
        }
    }

    public string getText(string key)
    {
        return LocalizationManager.Instance.GetText(key);
    }
}
