using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Method : MonoBehaviour
{
    public Returner var;
    public Returner[] values;
    string varName;
    string[] valueTexts;
    protected string opSymbol;

    

    public Method(string varName, string[] valueTexts)
    {
        this.varName = varName;
        this.valueTexts = valueTexts;
        var.setText(varName);
        var.setIsVar(true);
        foreach (Returner value in values)
        {
            value.setText(valueTexts[Array.IndexOf(values, value)]);
        }
    }

    public void MoveUp()
    {
        if (transform.GetSiblingIndex() > 2)
        {
            transform.SetSiblingIndex(transform.GetSiblingIndex() - 1);
        }
    }

    public void MoveDown()
    {
        if (transform.GetSiblingIndex() < transform.parent.childCount - 2)
        {
            transform.SetSiblingIndex(transform.GetSiblingIndex() + 1);
        }
    }



    public void Destroy()
    {
        Destroy(gameObject);
    }

    public virtual string onExecute()
    {
        string result = var.getText() + " = " + values[0].getText() + " " + opSymbol + " " + values[1].getText() + "\n";
        return result;
    }
    public void setAsInitial(string[] initValues)
    {
        int iterator = 0;
        GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        Component[] children  = GetComponentsInChildren<Transform>();
        foreach (Component child in children)
        {
            if (child.CompareTag("Returner"))
            {
                child.gameObject.GetComponentInChildren<Button>().interactable = false;
                if(iterator == 0)
                {
                    var.setText(initValues[iterator]);
                }
                else
                {
                    values[iterator-1].setText(initValues[iterator]);
                }
                iterator++;
            }
            if(child.name == "KillButton")
            {
                child.gameObject.SetActive(false);
            }

        }

    }

}
