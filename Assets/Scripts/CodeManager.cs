using UnityEngine;

public class CodeManager : MonoBehaviour
{
    private int varCount = 0;
    public GameObject var;
    public GameObject PopUpPanel;
    public Transform GroupTransform;

   
    public void createVar() {
        if (varCount < 4)
        {
            GameObject newVar = Instantiate(var, GroupTransform);
            varCount++;
        }
        else
        {
            Debug.Log("No se pueden crear más variables");
            return;
        }
        
    }

    public void closePopUp()
    {
        PopUpPanel.SetActive(false);
    }

}
