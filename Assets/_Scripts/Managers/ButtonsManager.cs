using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void NextLevelButton()
    {
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            AsyncOperation asyn = SceneManager.LoadSceneAsync(Random.Range(1, 8));
        }

        else if (SceneManager.GetActiveScene().buildIndex < 8)
        {
            AsyncOperation asyn = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
