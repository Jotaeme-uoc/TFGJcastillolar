using UnityEngine;
using UnityEngine.UI;

public class ProgressManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject[] progressObjects;
    private int progress;

    void Start()
    {
        progress = PlayerPrefs.GetInt("Progress");
        progressObjects = GameObject.FindGameObjectsWithTag("ProgressObject");
        foreach (GameObject progressObject in progressObjects)
        {
            Debug.Log("Progress Object: " + progressObject.name);
            int progressRequired = progressObject.GetComponent<LessonSelect>().progressRequired;
            if (progress < progressRequired)
            {
                progressObject.SetActive(false);
            }
        }
    }

    public void setProgress(int progress)
    {
        PlayerPrefs.SetInt("Progress", progress);
    }

    

    
}
