using System;
using System.Collections;
using System.Collections.Generic;
using MuhammetInce.DesignPattern.Singleton;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
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
        neededPenguinText.text = "Needed Penguin : " + levelMatchNeeded;
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
