using UnityEngine;

public class CodeManager : MonoBehaviour
{
    private int offset = 10;
    public GameObject var;
    public Transform CanvasTransform;

    public void createVar() { 
        Instantiate(var, CanvasTransform);
    }


}
