using TMPro;
using UnityEngine;

public class PrintMethod : MonoBehaviour
{
    private string fieldText;
    public TextMeshProUGUI toPrint;
    public string onExecute()
    {
        fieldText = toPrint.text;
        return "return " + fieldText;
    }
}
