using UnityEngine;

public class VarListContainer : MonoBehaviour
{
    public GameObject UIManager;

    private void OnEnable()
    {
        UIManager uiManager = GameObject.FindGameObjectsWithTag("UIManager")[0].GetComponent<UIManager>();
        uiManager.varMenu();
    }


}
