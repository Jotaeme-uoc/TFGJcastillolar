using UnityEngine;
using MoonSharp.Interpreter;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class LogicManager : MonoBehaviour
{
    private string solutionScript;
    private ArrayList randomValues;
    public GameObject variables;
    public GameObject methods;
    public UIManager uiManager;
    IExcerciseSceneConfig sceneConfig;
    private ICustomScript customScript;
    public void Start()
    {
        try
        {
            customScript = GameObject.FindGameObjectWithTag("CustomExecuter").GetComponent<ICustomScript>();
        }catch(NullReferenceException e)
        {
            Debug.Log("No custom script found");
            customScript = null;
        }
        
        randomValues = new ArrayList();
        sceneConfig = (IExcerciseSceneConfig)SceneConfigLoader.Load(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Script script = new Script();
        solutionScript = sceneConfig.solvedExercise;
    }

    private List<string> defineVars()
    {
        List<string> code = new List<string> { }; ;
        for (int i = 0; i < variables.transform.childCount; i++)
        {
            GameObject child = variables.transform.GetChild(i).gameObject;
            if (child.CompareTag("Var"))
            {
                Var var = child.GetComponent<Var>();
                string line = var.onExecute();
                if (var.getIsRandom())
                {
                    line += randomNumber() + "\n";
                }
                code.Add(line);
            }
        }
        return code;
    }

    private List<string> defineOperations() { 
        List<string> code = new List<string> { };
        for (int i = 0; i < methods.transform.childCount; i++)
        {
            GameObject child = methods.transform.GetChild(i).gameObject;
            if (child.CompareTag("Method"))
            {
                Method method = child.GetComponent<Method>();
                string line = method.onExecute();
                code.Add(line);
            }
            if (child.CompareTag("PrintMethod"))
            {
                PrintMethod printMethod = child.GetComponent<PrintMethod>();
                string line = printMethod.onExecute();
                code.Add(line);
            }
        }
        return code;
    }

    private string defineRandomVariablesForSolutionScript()
    {
        string code = "";
        for (int i = 0; i < randomValues.Count; i++)
        {
            code += "var" + (i + 1) + " = " + randomValues[i] + "\n";
        }
        return code;
    }

    public void Execute()
    {
        if (uiManager.checkNoReturnerIsEmpty() && uiManager.checkRequiredVars())
        {
            if (customScript != null)
            {
                customScript.Execute();
            }
            else
            {
                Script script = new Script();
                Script solutionS = new Script();
                List<string> code = new List<string> { };


                code.AddRange(defineVars());
                code.AddRange(defineOperations());

                solutionScript = defineRandomVariablesForSolutionScript() + solutionScript;

                //Debug.Log("Ejercicio:" + createScript(code));
                //Debug.Log("Solucion:" + solutionScript);

                string solution = solutionS.DoString(solutionScript).CastToString();
                string res = script.DoString(createScript(code)).CastToString();
                
                if (solution == res)
                {
                    saveProgress();
                    uiManager.mostrarResultado(res, true);
                }
                else
                {
                    uiManager.mostrarResultado(res, false);
                }
                randomValues.Clear();
                solutionScript = sceneConfig.solvedExercise;
            }
        }
        else
        {
            return;
        }
    }
    private string createScript(List<string> script)
    {
        string scriptCode = "";
        foreach (string line in script)
        {
            scriptCode += line;
        }
        Debug.Log(scriptCode);
        return scriptCode;
    }

    public int randomNumber()
    {

        int random =  UnityEngine.Random.Range(1, 7);
        if(randomValues.Count < 6)
        {
            while (randomValues.Contains(random))
            {
                Debug.Log("Random number already exists: " + random);
                random = UnityEngine.Random.Range(1, 7);
            }
        }
        randomValues.Add(random);
        return random;
    }

    public void saveProgress()
    {
        int progress = PlayerPrefs.GetInt("Progress");
        if (progress < UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("Progress", UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
        
    }
}




