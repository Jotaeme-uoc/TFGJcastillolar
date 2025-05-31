using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject[] methods;
    public Button createVarButton;
    public Button manualValueButton;
    public Button createMethodButton;
    public GameObject variables;
    public GameObject buttonContainer;
    public GameObject code;
    public GameObject var;
    public GameObject optionPrefab;
    public GameObject varListContainer;
    public GameObject methodListContainer;
    public GameObject returnerPopUp;
    public GameObject varSelectorPopUp;
    public GameObject varCreationPopUp;
    public GameObject methodSelectionPopUp;
    public GameObject manualValuePopUp;
    public GameObject resultPopUp;
    private Returner currentReturner;
    public GameObject PopUpPanel;
    public TextMeshProUGUI message;
    public Button printMehtodButton;
    public ExcerciseTextManager exerciseTextManager;
    IExcerciseSceneConfig sceneConfig;

    public void activateResultButtons()
    {
        buttonContainer.SetActive(true);
    }
    public void changeCurrentReturnerText(string newText)
    {
        if (currentReturner != null)
        {
            currentReturner.CambiarTexto(newText);
        }
    }

    //si el valor no es un numero, devuelve false y muestra el mensaje de error en el warning
    private bool checkIsNumber(TMP_Text warning, string value)
    {
        if (sceneConfig.stringsAllowed)
        {
            return true;
        }
        if (int.TryParse(value, out int numero))
        {
            return true;
        }
        else
        {
            warning.text = exerciseTextManager.getText("Warning_Value_Number");
            return false;
        }

    }

    //si el valor es un numero, devuelve false y muestra el mensaje de error en el warning
    private bool checkIsNotNumber(TMP_Text warning, string value)
    {
        if (!int.TryParse(value[0].ToString(), out int numero))
        {
            return true;
        }
        else
        {
            warning.text = exerciseTextManager.getText("Warning_Incorrect_Varname");
            return false;
        }
    }

    private bool checkIsNotEmpty(TMP_Text warning, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            return true;
        }
        else
        {
            warning.text = exerciseTextManager.getText("Warning_Empty_Field");
            return false;
        }

    }

    private bool checkIsNotRepeated(TMP_Text warning, string varName)
    {
        List<string> variablesNames = getAllVariables();
        if (!variablesNames.Contains(varName))
        {
            return true;
        }
        else
        {
            warning.text = exerciseTextManager.getText("Warning_Duplicate_Var");
            return false;
        }
    }

    public bool checkNoReturnerIsEmpty(){
        String message = exerciseTextManager.getText("Warning_Empty_Returner");
        GameObject[] returners = GameObject.FindGameObjectsWithTag("Returner");
        Debug.Log(returners.Length);
        foreach (GameObject returner in returners)
        {
            if (returner.GetComponentInChildren<TextMeshProUGUI>().text == "?")
            {
                mostrarResultado(message, false);
                return false;
            }            
        }
        return true;
    }
    public bool checkqMarks(TMP_Text warning, string value)
    {
        if (float.TryParse(value, out float numero))
        {
            return true;
        }
        else
        {
            if (value[0] == '"' && value[value.Length - 1] == '"' )
            {
                return true;
            }
            else
            {
                warning.text = exerciseTextManager.getText("Warning_No_QMarks");
                return false;
            }
        }
    }
    public bool checkRequiredVars()
    {
        String message = exerciseTextManager.getText("Warning_Required_Vars");
        GameObject[] vars = GameObject.FindGameObjectsWithTag("Var");
        Dictionary<string, string> varsToCheck = sceneConfig.varsToCheck;
        Dictionary<string, string> createdVars = new Dictionary<string, string>();
        Debug.Log("Variables Creadas");
        foreach (GameObject var in vars)
        {
            Var varScript = var.GetComponent<Var>();
            Debug.Log(varScript.getName());
            createdVars.Add(varScript.getName(), varScript.getValue());
        }
        foreach (KeyValuePair<string, string> kvp in varsToCheck)
        {
            if (!createdVars.ContainsKey(kvp.Key) && kvp.Key!="0")
            {
                mostrarResultado(message, false);
                return false;
            }
            if (!createdVars.ContainsValue(kvp.Value) && kvp.Value!="a")
            {
                Debug.Log("No se ha encontrado el valor " + kvp.Value);
                mostrarResultado(message, false);
                return false;
            }
        }
        return true;
    }

    public void createMethod()
    {
        cleanSelector(methodListContainer);
        methodSelectionPopUp.SetActive(true);
        foreach(GameObject method in methods)
        {
            GameObject methodOption = Instantiate(optionPrefab, methodListContainer.transform);
            TextMeshProUGUI methodOptionText = methodOption.GetComponentInChildren<TextMeshProUGUI>();
            Button methodOptionButton = methodOption.GetComponentInChildren<Button>();
            methodOptionText.text = exerciseTextManager.getText(method.name);
            methodOptionButton.onClick.AddListener(() => methodSelected(method));
        }       
    }
    public void createVar()
    {
        int varCount = variables.transform.childCount - 2;
        if (varCount < sceneConfig.varLimit)
        {
            TMP_InputField[] inputFields = varCreationPopUp.GetComponentsInChildren<TMP_InputField>();
            foreach (TMP_InputField inputField in inputFields)
            {
                inputField.text = "";
            }
            varCreationPopUp.SetActive(true);
        }
        else
        {
            return;
        }
    }

    private void enableCreateButton()
    {
        if (!sceneConfig.canCreateVariables)
        {
            createVarButton.interactable = false;
        }
        if (!sceneConfig.canCreateMethods)
        {
            createMethodButton.interactable = false;
        }
    }
    private void enableManualValues()
    {
        if (!sceneConfig.manualValuesAllowed)
        {
            manualValueButton.interactable = false;
        }
    }
    public void initialVars()
    {
        Dictionary<string, (string val, bool isRandom)> vars = sceneConfig.vars;
        foreach (KeyValuePair<string, (string val, bool isRandom)> kvp in vars)
        {
            GameObject newVar = Instantiate(var, variables.transform);
            Var varScript = newVar.GetComponent<Var>();
            varScript.setName(kvp.Key);
            varScript.setValue(kvp.Value.val);
            varScript.setAsInitial(kvp.Value.isRandom);
        }
    }

    private void initialMethods()
    {
        Dictionary<string, string[]> initMethods = sceneConfig.methods;
        foreach (KeyValuePair<string, string[]> kvp in initMethods)
        {
            string varName = kvp.Value[0];
            string[] values = kvp.Value[1..];
            switch (kvp.Key)
            {
                case "AddMethod":
                    GameObject addMethod = Instantiate(methods[0], code.transform);
                    addMethod.GetComponent<AddMethod>().setAsInitial(kvp.Value);
                    moveToPenultimate(addMethod.GetComponent<Method>());
                    break;
                case "AssignMethod":
                    GameObject assignMethod = Instantiate(methods[1], code.transform);
                    assignMethod.GetComponent<AssignMethod>().setAsInitial(kvp.Value);
                    moveToPenultimate(assignMethod.GetComponent<Method>());
                    break;
                case "DivideMethod":
                    GameObject divideMethod = Instantiate(methods[2], code.transform);
                    divideMethod.GetComponent<DivideMethod>().setAsInitial(kvp.Value);
                    moveToPenultimate(divideMethod.GetComponent<Method>());
                    break;
                case "ModMethod":
                    GameObject modMethod = Instantiate(methods[3], code.transform);
                    modMethod.GetComponent<ModMethod>().setAsInitial(kvp.Value);
                    moveToPenultimate(modMethod.GetComponent<Method>());
                    break;
                case "MultiplyMethod":
                    GameObject multiplyMethod = Instantiate(methods[4], code.transform);
                    multiplyMethod.GetComponent<MultiplyMethod>().setAsInitial(kvp.Value);
                    moveToPenultimate(multiplyMethod.GetComponent<Method>());
                    break;
                case "SubstractMethod":
                    GameObject subtractMethod = Instantiate(methods[5], code.transform);
                    subtractMethod.GetComponent<SubstractMethod>().setAsInitial(kvp.Value);
                    moveToPenultimate(subtractMethod.GetComponent<Method>());
                    break;
                default:
                    Debug.Log("No se ha encontrado el metodo " + kvp.Key);
                    break;
            }
        }
    }
    private void cleanSelector(GameObject selector)
    {
        foreach (Transform child in selector.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void fillPrintMethod()
    {
        string printMethodInitialValue = sceneConfig.printMethodInitialValue;
        if (!string.IsNullOrEmpty(printMethodInitialValue))
        {
            printMehtodButton.GetComponentInChildren<TextMeshProUGUI>().text = printMethodInitialValue;
            printMehtodButton.interactable = false;
        }
        
    }
    private TMP_Text getWarningText(GameObject popUp)
    {
        TMP_Text warning = null;
        TMP_Text[] tMP_Texts = popUp.GetComponentsInChildren<TMP_Text>(true);
        foreach (TMP_Text tMP_Text in tMP_Texts)
        {
            if (tMP_Text.CompareTag("Warning"))
            {
                warning = tMP_Text;
                break;
            }
        }
        if (warning == null)
        {
            Debug.LogError("No se encontró el texto de advertencia en el popUp");
        }
        return warning;
    }

    public List<string> getAllVariables()
    {
        int varCount = variables.transform.childCount;
        List<string> varNames = new List<string>();
        for (int i = 0; i < varCount; i++)
        {
            GameObject child = variables.transform.GetChild(i).gameObject;
            if (child.CompareTag("Var"))
            {
                Var var = child.GetComponent<Var>();
                varNames.Add(var.getName());
            }
        }
        return varNames;
    }

    public void manualValueintroduced()
    {
        TMP_Text warning = getWarningText(manualValuePopUp);
        TMP_InputField inputField = manualValuePopUp.GetComponentInChildren<TMP_InputField>();
        string value = inputField.text;
        if (checkIsNotEmpty(warning, value) && checkIsNumber(warning, value) && checkqMarks(warning, value))
        {
            currentReturner.setIsVar(false);
            currentReturner.CambiarTexto(value);
            inputField.text = "";
            manualValuePopUp.SetActive(false);
            warning.gameObject.SetActive(false);
        }
        else
        {
            warning.gameObject.SetActive(true);
            return;
        }
    }

    public void methodSelected(GameObject method)
    {
        GameObject newMethod = Instantiate(method, code.transform);
        moveToPenultimate(newMethod.GetComponent<Method>());
        methodSelectionPopUp.SetActive(false);
    }

    public void mostrarResultado(string mensaje, Boolean success)
    {
        resultPopUp.SetActive(true);
        TextMeshProUGUI resultText = resultPopUp.GetComponentInChildren<TextMeshProUGUI>();
        if (success)
        {
            resultText.text = exerciseTextManager.getText("Success");
            activateResultButtons();
        }
        else
        {
            resultText.text = exerciseTextManager.getText("Fail");
        }
            
        resultText.text += "\n" + mensaje;
    }

    public void moveToPenultimate(Method newMethod)
    {
        int childcount = code.transform.childCount;
        int penultimateIndex = Math.Max(0, childcount - 2);
        newMethod.transform.SetSiblingIndex(penultimateIndex);
    }

    
    public void setAvailableMethods()
    {
        string[] availableMethods = sceneConfig.availableMethods;
        foreach (GameObject method in methods)
        {
            if (!availableMethods.Contains(method.name))
            {
                methods = methods.Where(m => m != method).ToArray();
            }
        }
    }
    public void setCurrentReturner(Returner returner)
    {
        currentReturner = returner;
        if (returner.isOut)
        {
            varSelectorPopUp.SetActive(true);
            varMenu();
        }
        else
        {
            returnerPopUp.SetActive(true);
        }
    }

    public void showTutorial()
    {
        PopUpPanel.SetActive(true);
        message.text = exerciseTextManager.getText($"{sceneConfig.formulation}");
    }

    private void Start()
    {
        methods = Resources.LoadAll<GameObject>("Prefabs/Methods");
        sceneConfig = (IExcerciseSceneConfig)SceneConfigLoader.Load(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        showTutorial();
        initialVars();
        initialMethods();
        setAvailableMethods();
        enableCreateButton();
        enableManualValues();
        fillPrintMethod();
    }

    public void varMenu()
    {
        cleanSelector(varListContainer);
        List<string> variablesNames = getAllVariables();
        foreach (string varName in variablesNames)
        {
            GameObject varOption = Instantiate(optionPrefab, varListContainer.transform);
            TextMeshProUGUI varOptionText = varOption.GetComponentInChildren<TextMeshProUGUI>();
            Button varOptionButton = varOption.GetComponentInChildren<Button>();
            varOptionText.text = varName;
            varOptionButton.onClick.AddListener(() => varSelected(varName));
        }

    }

    public void varSelected(string varName)
    {
        currentReturner.setIsVar(true);
        changeCurrentReturnerText(varName);
        varSelectorPopUp.SetActive(false);
    }

    public void varValuesAccepted()
    {
        TMP_Text warning = getWarningText(varCreationPopUp);
        TMP_InputField[] inputFields = varCreationPopUp.GetComponentsInChildren<TMP_InputField>();
        string name = inputFields[0].text;
        string value = inputFields[1].text;
        if (checkIsNotEmpty(warning, name) && checkIsNotEmpty(warning, value) && checkIsNotNumber(warning, name)
            && checkIsNumber(warning, value) && checkIsNotRepeated(warning, name))
        {
            GameObject newVar = Instantiate(var, variables.transform);
            Var varScript = newVar.GetComponent<Var>();
            varScript.setName(name);
            varScript.setValue(value);
            varCreationPopUp.SetActive(false);
            warning.gameObject.SetActive(false);
        }
        else
        {
            warning.gameObject.SetActive(true);
            return;
        }

    }
}
