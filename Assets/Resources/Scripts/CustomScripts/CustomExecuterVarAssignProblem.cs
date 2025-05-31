using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CustomExecuterVarAssignProblem : MonoBehaviour, ICustomScript
{
    public TextMeshProUGUI toPrint;
    public LogicManager logicManager;

    
    public void Execute()
    {
        toPrint.text = "tostring(x) .. \" \" .. tostring(y)";
        logicManager.Execute();
        toPrint.text = "x, y";
    }

    
}


