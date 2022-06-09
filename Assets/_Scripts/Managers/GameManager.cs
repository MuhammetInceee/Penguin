using MuhammetInce.DesignPattern.Singleton;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    private float _leftPenguin;
    
    [Header("About Matched Penguin: "), Space]
    public float matchedPenguin;
    [SerializeField] private float levelMatchNeeded;

    [Space] [Header("About Game End Canvas: "), Space] 
    [SerializeField] private float visualizeDelayer;
    [SerializeField] private GameObject levelEndedScreen;

    [Space] [Header("About Gameplay Canvas: "), Space] 
    [SerializeField] private TextMeshProUGUI neededPenguinText;

    private void Update() => UpdateInit();
    

    private void UpdateInit()
    {
        GameEndChecker();
        _leftPenguin = levelMatchNeeded - matchedPenguin;
        neededPenguinText.text = "Match needed to penguins  : " + _leftPenguin;
    }

    private void GameEndChecker()
    {
        if (matchedPenguin >= levelMatchNeeded)
        {
            visualizeDelayer -= Time.deltaTime;
            
            if (visualizeDelayer <= 0)
            {
                if (!levelEndedScreen.activeInHierarchy)
                {
                    levelEndedScreen.SetActive(true);
                }
                    
            }
        }
    }
}
