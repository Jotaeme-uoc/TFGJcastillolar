using TMPro;
using UnityEngine;

public class PrintMethod : MonoBehaviour, Method
{
    private string fieldText;
    public TextMeshProUGUI toPrint;
    public string onExecute()
    {
        fieldText = toPrint.text;
        return "return " + fieldText;

    }

    public void Destroy()
    {
        //El metodo print no puede quitarse, ya que es el output del programa
        return;
    }

}
