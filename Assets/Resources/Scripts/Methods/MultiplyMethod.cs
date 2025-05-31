using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class MultiplyMethod : Method
{
    public MultiplyMethod(string var, string[] values) : base(var, values)
    {
        this.opSymbol = "*";
    }

    private void Awake()
    {
        this.opSymbol = "*";
    }
}
