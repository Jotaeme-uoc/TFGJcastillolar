using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Var : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string name;
    private string value;
    private bool isRandom;
    public TMP_InputField inputName;
    public TMP_InputField inputValue;
    public GameObject deleteButton;
    public Image background;
    public Image isRandomIcon;


    public string onExecute()
    {
        name = inputName.text;
        if (isRandom)
        {
            return name + " = ";
        }
        else
        {
            value = inputValue.text;
            return name + " = " + value + "\n";
        }
    }

    public void Destroy()
    { 
        Destroy(gameObject);
    }


    public string getName()
    {
        return inputName.text;
    }

    public string getValue()
    {
        return inputValue.text;
    }

    public bool getIsRandom()
    {
        return isRandom;
    }

    public void setName(string newName)
    {
        name = newName;
        inputName.text = newName;
    }

    public void setValue(string newValue)
    {
        value = newValue;
        inputValue.text = newValue;
    }

    public void setAsInitial(bool isRandom)
    {
        this.isRandom = isRandom;
        if (isRandom)
        {
            inputValue.gameObject.SetActive(false);
            isRandomIcon.gameObject.SetActive(true);
        }
        inputName.interactable = false;
        inputValue.interactable = false;
        deleteButton.SetActive(false);
        background.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
