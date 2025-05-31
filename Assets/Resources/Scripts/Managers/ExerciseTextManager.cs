using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExcerciseTextManager : MonoBehaviour
{
    public TextMeshProUGUI checkHomeText;
    public TextMeshProUGUI buttonYes;
    public TextMeshProUGUI buttonNo;
    public TextMeshProUGUI variablesText;
    public TextMeshProUGUI methodsText;
    public TextMeshProUGUI[] insertValue;
    public TextMeshProUGUI[] accept;
    public TextMeshProUGUI[] chooseVarFromList;
    public TextMeshProUGUI inserVarName;
    public TextMeshProUGUI chooseOption;
    public TextMeshProUGUI insertManualValue;
    public TextMeshProUGUI chooseMethodFromList;
    public TextMeshProUGUI printMethod;
    public TextMeshProUGUI home;
    public TextMeshProUGUI next;

    int currentPage = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        checkHomeText.text = getText("Check_Home");
        buttonYes.text = getText("Button_Yes");
        buttonNo.text = getText("Button_No");
        variablesText.text = getText("Variables");
        methodsText.text = getText("Methods");
        inserVarName.text = getText("Insert_Var_Name");
        chooseOption.text = getText("Choose_Option");
        insertManualValue.text = getText("Insert_Manual_Value");
        chooseMethodFromList.text = getText("Choose_Method_List");
        printMethod.text = getText("PrintMethod");
        home.text = getText("Home");
        next.text = getText("Next_Lesson");
        foreach (TextMeshProUGUI text in accept)
        {
            text.text = getText("Accept");
        }
        foreach (TextMeshProUGUI text in insertValue)
        {
            text.text = getText("Insert_Value");
        }
        foreach (TextMeshProUGUI text in chooseVarFromList)
        {
            text.text = getText("Choose_Var_List");
        }

    }

    public string getText(string key)
    {
        return LocalizationManager.Instance.GetText(key);
    }
}
