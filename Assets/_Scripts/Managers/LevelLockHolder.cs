using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class LevelLockHolder : MonoBehaviour
{
    [Header("About Button and Its Images: "), Space]
    [SerializeField] private List<Button> levelButtonList = new List<Button>();
    [SerializeField] private List<GameObject> levelLocker = new List<GameObject>();
    
    private void Update() => UpdateInit();
    private void UpdateInit()
    {
        LevelButtonsLockChecker();
        LockerImageController();
    }

    private void LevelButtonsLockChecker()
    {
        levelButtonList[0].enabled = PlayerPrefs.GetInt("Level2Lock") != 0;
        levelButtonList[1].enabled = PlayerPrefs.GetInt("Level3Lock") != 0;
        levelButtonList[2].enabled = PlayerPrefs.GetInt("Level4Lock") != 0;
        levelButtonList[3].enabled = PlayerPrefs.GetInt("Level5Lock") != 0;
        levelButtonList[4].enabled = PlayerPrefs.GetInt("Level6Lock") != 0;
        levelButtonList[5].enabled = PlayerPrefs.GetInt("Level7Lock") != 0;
        levelButtonList[6].enabled = PlayerPrefs.GetInt("Level8Lock") != 0;
    }

    private void LockerImageController()
    {
        levelLocker[0].SetActive(PlayerPrefs.GetInt("Level2Lock") == 0);
        levelLocker[1].SetActive(PlayerPrefs.GetInt("Level3Lock") == 0);
        levelLocker[2].SetActive(PlayerPrefs.GetInt("Level4Lock") == 0);
        levelLocker[3].SetActive(PlayerPrefs.GetInt("Level5Lock") == 0);
        levelLocker[4].SetActive(PlayerPrefs.GetInt("Level6Lock") == 0);
        levelLocker[5].SetActive(PlayerPrefs.GetInt("Level7Lock") == 0);
        levelLocker[6].SetActive(PlayerPrefs.GetInt("Level8Lock") == 0);
    }
}
