using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class DivideMethod : Method
{
    public DivideMethod(string var, string[] values) : base(var, values)
    {
        this.opSymbol = "/";
    }

    private void Awake()
    {
        this.opSymbol = "/";
    }

    public override string onExecute()
    {
        string result = var.getText() + " = math.floor(" + values[0].getText() + " " + opSymbol + " " + values[1].getText() + ")\n";
        return result;
    }
}
