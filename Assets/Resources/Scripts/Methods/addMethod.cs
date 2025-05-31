using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class AddMethod : Method
{
    public AddMethod(string var, string[] values) : base(var, values)
    {
        this.opSymbol = "+";
    }

    private void Awake()
    {
        this.opSymbol = "+";
    }
}
