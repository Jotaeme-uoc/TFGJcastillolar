using UnityEngine;

public class CustomSceneManager : MonoBehaviour
{
    public void Home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
