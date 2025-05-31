using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CustomScriptVarCreationExercise1 : MonoBehaviour, ICustomScript
{
    public GameObject UIManager;
    public TextMeshProUGUI toPrint;
    private Var var;
    private UIManager uiManager;
    public ExcerciseTextManager exerciseTextManager;
    public LogicManager logicManager;

    private void Start()
    {

        uiManager = UIManager.GetComponent<UIManager>();
    }
    public void Execute()
    {
        try
        {
            var = GameObject.FindGameObjectWithTag("Var").GetComponent<Var>();
        }catch(NullReferenceException e)
        {
            uiManager.mostrarResultado(exerciseTextManager.getText("Error_VarCreationExercise1"), false);
        }
        
        if (var.getName() == toPrint.text)
        {
            uiManager.mostrarResultado(var.getValue(), true);
            logicManager.saveProgress();
        }
        else
        {
            uiManager.mostrarResultado(var.getValue(), false);
        }
        
    }

    
}


