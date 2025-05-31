using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class ModMethod : Method
{
    public ModMethod(string var, string[] values) : base(var, values)
    {
        this.opSymbol = "%";
    }

    private void Awake()
    {
        this.opSymbol = "%";
    }
}
