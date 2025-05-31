using TMPro;
using UnityEngine;

public class AssignMethod : Method
{
    public AssignMethod(string var, string[] values) : base(var, values)
    {
        this.opSymbol = " ";
    }
    private void Awake()
    {
        this.opSymbol = " ";
    }

    override
    public string onExecute()
    {
        if (float.TryParse(values[0].getText(), out float num) || values[0].getIsVar())
        {
            return var.getText() + " = " + values[0].getText() + "\n";
        }
        else
        {
            return var.getText() + " = \"" + values[0].getText() + "\"\n";
        }
        
    }
}
