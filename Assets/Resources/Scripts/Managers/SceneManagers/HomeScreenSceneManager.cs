using UnityEngine;

public class HomeScreenSceneManager : MonoBehaviour
{
    public void LoadLessonsScene()
    {
        // Load the lessons scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
