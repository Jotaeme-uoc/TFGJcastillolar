using UnityEngine;
using MoonSharp.Interpreter;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    public GameObject variables;
    public GameObject methods;
    public TMP_InputField toPrint;
    public UIManager uiManager;

    public void Start()
    {
        Script script = new Script();
        List<string> code = new List<string> { };
        code.Add("x = 5\n");
        code.Add("y = 10\n");
        code.Add("z = x + y\n");
        code.Add("return z\n");


        DynValue res = script.DoString(createScript(code));
        Debug.Log(res.Number);
    }

    public void Execute()
    {
        if (uiManager.checkNoReturnerIsEmpty())
        {
            Script script = new Script();
            List<string> code = new List<string> { };

            for (int i = 0; i < variables.transform.childCount; i++)
            {
                GameObject child = variables.transform.GetChild(i).gameObject;
                if (child.CompareTag("Var"))
                {
                    Var var = child.GetComponent<Var>();
                    string line = var.onExecute();
                    code.Add(line);
                }
            }

            for (int i = 0; i < methods.transform.childCount; i++)
            {
                GameObject child = methods.transform.GetChild(i).gameObject;
                if (child.CompareTag("Method"))
                {
                    Method method = child.GetComponent<Method>();
                    string line = method.onExecute();
                    code.Add(line);
                }
            }

            DynValue res = script.DoString(createScript(code));
            uiManager.mostrarResultado(res.Number.ToString());
            Debug.Log(res.Number);

            /*string message = "";
            string variableToPrint = toPrint.text;
            if (variableToPrint == "")
            {
                message = "Inserta el nombre de una variable para imprimirla";
                mostrarResultado(message);
            }
            else {
                message = "La variable que has introducido no existe";
                GameObject[] variables = GameObject.FindGameObjectsWithTag("Var");
                foreach (GameObject variable in variables)
                {
                    Var var = variable.GetComponent<Var>();
                    if (var.getName() == variableToPrint)
                    {
                        message = var.getValue();
                        break;
                    }
                }
                mostrarResultado(message);
            }*/

        }
        else
        {
            return;
        }
    }

    


    double MoonSharpFactorial()
    {
        string scriptCode = @"    
		-- defines a factorial function
		function fact (n)
			if (n == 0) then
				return 1
			else
				return n*fact(n - 1)
			end
		end

		return fact(5)";

        Script script = new Script();
        DynValue res = script.DoString(scriptCode);
        return res.Number;
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
}




