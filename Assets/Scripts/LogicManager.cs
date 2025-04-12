using UnityEngine;
using MoonSharp.Interpreter;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class LogicManager : MonoBehaviour
{

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
        Debug.Log("Ejecutandome");
        GameObject[] variables = GameObject.FindGameObjectsWithTag("Var");
        foreach(GameObject variable in variables)
        {
           Debug.Log(variable.GetComponent<Var>().onExecute());
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
        return scriptCode;
    }
}




