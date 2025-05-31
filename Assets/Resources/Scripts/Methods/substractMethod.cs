using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class SubstractMethod : Method
{
    public SubstractMethod(string var, string[] values): base(var, values)
    {
        this.opSymbol = "-";
    }

    private void Awake()
    {
        this.opSymbol = "-";
    }
}
