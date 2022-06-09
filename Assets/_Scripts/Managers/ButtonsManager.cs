using UnityEngine.SceneManagement;
using UnityEngine;

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
        PassLevel();
        PlayerPrefsControl();
    }

    private void PassLevel()
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

    private void PlayerPrefsControl()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                PlayerPrefs.SetInt("Level2Lock", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Level3Lock", 1);
                break;
            case 3:
                PlayerPrefs.SetInt("Level4Lock", 1);
                break;
            case 4:
                PlayerPrefs.SetInt("Level5Lock", 1);
                break;
            case 5:
                PlayerPrefs.SetInt("Level6Lock", 1);
                break;
            case 6:
                PlayerPrefs.SetInt("Level7Lock", 1);
                break;
            case 7:
                PlayerPrefs.SetInt("Level8Lock", 1);
                break;
        }
    }
    
}
