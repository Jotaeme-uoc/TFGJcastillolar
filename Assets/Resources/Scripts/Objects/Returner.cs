using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;
using System;

public class Returner : MonoBehaviour
{
    private UnityEngine.UI.Button button;
    private TextMeshProUGUI text;
    private UIManager uiManager;
    public Boolean isVar;

    void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        button = GetComponent<UnityEngine.UI.Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        button.onClick.AddListener(AlPulsar);
    }

    void AlPulsar()
    {
        uiManager.setCurrentReturner(this);
    }

    public void CambiarTexto(string newText)
    {
        text.text = newText;
    }
}
