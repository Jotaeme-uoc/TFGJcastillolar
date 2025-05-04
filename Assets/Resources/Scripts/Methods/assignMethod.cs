using TMPro;
using UnityEngine;

public class assignMethod : MonoBehaviour, Method
{
    public TextMeshProUGUI var;
    public TextMeshProUGUI value;

    public string onExecute()
    {
        return var.text + " = " + value.text + "\n";
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
