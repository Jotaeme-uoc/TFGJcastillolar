using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CustomScriptRandomVars : MonoBehaviour, ICustomScript
{
    public GameObject UIManager;
    private UIManager uiManager;
    public ExcerciseTextManager exerciseTextManager;
    public GameObject resultButtons;
    public LogicManager logicManager;
    int executeCount = 0;
    private void Start()
    {
        uiManager = UIManager.GetComponent<UIManager>();
    }
    public void Execute()
    {
        executeCount++;
       if(executeCount < 3)
        {
            uiManager.mostrarResultado(exerciseTextManager.getText("RandomVars_Result" ) + logicManager.randomNumber(), true);
            resultButtons.SetActive(false);
        }
        else
        {
            uiManager.mostrarResultado(exerciseTextManager.getText("RandomVars_Result") + logicManager.randomNumber(), true);
            logicManager.saveProgress();
        } 
            
    }

    
}


