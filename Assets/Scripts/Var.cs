using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Var : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string name;
    private string value;
    public TMP_InputField inputName;
    public TMP_InputField inputValue;

    public string onExecute()
    {
        name = inputName.text;
        value = inputValue.text;
        return name + " = " + value + "\n";
    }

    public string getName()
    {
        return inputName.text;
    }

    public string getValue()
    {
        return inputValue.text;
    }
}
