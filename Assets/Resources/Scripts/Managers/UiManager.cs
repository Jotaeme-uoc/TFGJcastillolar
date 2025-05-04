using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameObject[] methods;
    public GameObject variables;
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
    private Returner currentReturner;
    public GameObject PopUpPanel;
    public TextMeshProUGUI message;


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
        if (int.TryParse(value, out int numero))
        {
            return true;
        }
        else
        {
            warning.text = "El valor debe ser un numero";
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
            warning.text = "El nombre no puede ser un numero o empezar por un numero";
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
            warning.text = "Ningún campo puede estar vacio";
            return false;
        }

    }

    private bool checkIsNotRepeated(TMP_Text warning, string varName)
    {
        List<string> variablesNames = getAllVariables();
        if (!variablesNames.Contains(varName))
        {
            Debug.Log("El nombre de la variable no existe");
            return true;
        }
        else
        {
            warning.text = "El nombre de la variable ya existe";
            return false;
        }
    }

    public bool checkNoReturnerIsEmpty(){
        String message = "Todos los valores vacíos (Marcados como \"?\") deben rellenarse para ejecutar el código";
        GameObject[] returners = GameObject.FindGameObjectsWithTag("Returner");
        Debug.Log(returners.Length);
        foreach (GameObject returner in returners)
        {
            if (returner.GetComponentInChildren<TextMeshProUGUI>().text == "?")
            {
                mostrarResultado(message);
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
            methodOptionText.text = method.name;
            methodOptionButton.onClick.AddListener(() => methodSelected(method));
        }       
    }
    public void createVar()
    {
        TMP_InputField[] inputFields = varCreationPopUp.GetComponentsInChildren<TMP_InputField>();
        foreach (TMP_InputField inputField in inputFields)
        {
            inputField.text = "";
        }
        varCreationPopUp.SetActive(true);
    }

    private void cleanSelector(GameObject selector)
    {
        foreach (Transform child in selector.transform)
        {
            Destroy(child.gameObject);
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
        if (checkIsNotEmpty(warning, value) && checkIsNumber(warning, value))
        {
            currentReturner.CambiarTexto(value);
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
        int childcount = code.transform.childCount;
        int penultimateIndex = Math.Max(0, childcount - 2);
        newMethod.transform.SetSiblingIndex(penultimateIndex);
        methodSelectionPopUp.SetActive(false);
    }

    public void mostrarResultado(string mensaje)
    {
        PopUpPanel.SetActive(true);
        message.text = mensaje;
    }

    public void setCurrentReturner(Returner returner)
    {
        currentReturner = returner;
        if (returner.isVar)
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
        message.text = "Para crear una variable, pulsa el símbolo + del apartado Variables.\nPara crear un método, pulsa el símbolo + del apartado métodos y selecciona qué método quieres crear.\nPara ejecutar el código, pulsa el botón de play en la parte inferior.\nLas interrogaciones son valores sin asignar, y pueden ser variables o números. Es necesario rellenarlos antes de ejecutar.\nEl método print es la salida del programa y muestra el valor que le pases por pantalla.";
    }

    private void Start()
    {
        methods = Resources.LoadAll<GameObject>("Prefabs/Methods");
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
