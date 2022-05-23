using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    
    [Header("Booleans")] 
    private bool _goLeft;
    private bool _goRight;
    private bool _goUp;
    private bool _goDown;

    [Header("Movement Buttons")] 
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [Space]

    [Header("Minimum Coordinate For Buttons")] 
    [SerializeField] private float minimumY;
    [SerializeField] private float maximumY;
    [SerializeField] private float minimumX;
    [SerializeField] private float maximumX;
    


    private void Update() => UpdateInit();

    private void UpdateInit()
    {
        ButtonChecker();
    }

    #region Movement Button

    private void ButtonChecker()
    {
        if (_goLeft)
            transform.Translate(new Vector2(-1 * playerSpeed * Time.deltaTime, 0));
        
        if (_goRight)
            transform.Translate(new Vector2(1 * playerSpeed * Time.deltaTime, 0));
        
        if (_goUp)
            transform.Translate(new Vector2(0, 1 * playerSpeed * Time.deltaTime));

        if (_goDown)
            transform.Translate(new Vector2(0, -1 * playerSpeed * Time.deltaTime));
    }

    public void LeftButtonMovement()
    {
        _goLeft = true;
        AllButtonInActive();
    }

    public void RightButtonMovement()
    {
        _goRight = true;
        AllButtonInActive();
    }

    public void UpButtonMovement()
    {
        _goUp = true;
        AllButtonInActive();
    }

    public void DownButtonMovement()
    {
        _goDown = true;
        AllButtonInActive();
    }

    #endregion

    #region ButtonsActiveChanger

    private void AllButtonInActive()
    {
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        upButton.gameObject.SetActive(false);
        downButton.gameObject.SetActive(false);
    }

    private void ButtonsActivator()
    {
        leftButton.gameObject.SetActive(true);
        rightButton.gameObject.SetActive(true);
        upButton.gameObject.SetActive(true);
        downButton.gameObject.SetActive(true);
    }


    #endregion
}