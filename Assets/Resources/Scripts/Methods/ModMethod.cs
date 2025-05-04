using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class ModMethod : MonoBehaviour, Method
{
    public TextMeshProUGUI var;
    public TextMeshProUGUI value1;
    public TextMeshProUGUI value2;

    public string onExecute()
    {
        string varText = var.text;
        string value1Text = value1.text;
        string value2Text = value2.text;
        return varText + " = " + value1Text + " % " + value2Text + "\n";
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
