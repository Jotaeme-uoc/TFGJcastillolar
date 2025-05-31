using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CustomExecuterExercise1 : MonoBehaviour, ICustomScript
{
    public GameObject UIManager;
    public TextMeshProUGUI toPrint;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.GetComponent<UIManager>();
    }
    public void Execute()
    {
        uiManager.mostrarResultado(toPrint.text, true);
    }

    
}


