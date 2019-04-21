using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{

    private PauseMenu pauseObjectsOnSceneLoad;

    private void Start()
    {
        pauseObjectsOnSceneLoad = GameObject.FindGameObjectWithTag("PauseMenuController").GetComponent<PauseMenu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadNextSceneIndex();
        }
    }

    public void LoadNextSceneIndex()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        pauseObjectsOnSceneLoad.HidePaused();
    }
}
