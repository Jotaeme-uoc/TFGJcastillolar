using UnityEngine;

public class returnerPopUp : MonoBehaviour
{
    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
