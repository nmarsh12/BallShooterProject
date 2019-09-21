using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    private int nextScene;
    private int currentScene;
    

    private void Start()
    {
        
    }
    
    void Update()
    {
        // temp test code...
        if (Input.GetKeyUp(KeyCode.Q))
        {
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;

            if(nextScene <= 5)
            {                
                SceneManager.LoadScene(nextScene);
            }

            else if (nextScene >= 6)
            {
                Debug.Log("All levels complete!");
            }
        }

        // temp test code... to reload current scene
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);           
        }

    }

    public void LoadNextlevel()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (nextScene <= 5)
        {
            SceneManager.LoadScene(nextScene);                       
        }

        else if (nextScene >= 6)
        {
            Debug.Log("All levels complete!");
        }
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();        
    }
}



