using System;
using System.Collections;
using System.Collections.Generic;
using MuhammetInce.DesignPattern.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("About Score: ")]
    public float score;
    
    [Space]
    [Header("About Active Penguin:")] 
    public List<GameObject> activePenguin = new List<GameObject>();

    [Space]
    [Header("About Game End Canvas:"), Space]
    [SerializeField] private GameObject levelEndedScreen;

    private void Start() => StartInit();

    private void Update() => UpdateInit();

    private void StartInit()
    {
        foreach (var gO in GameObject.FindGameObjectsWithTag("Penguin"))
        {
            activePenguin.Add(gO);
        }
    }

    private void UpdateInit()
    {
        //GameEndChecker();
    }

    private void GameEndChecker()
    {
        if (activePenguin.Count > 0) return;
        
        levelEndedScreen.SetActive(true);
    }
}
