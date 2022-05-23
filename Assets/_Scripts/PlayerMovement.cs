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

    [Space] [Header("Corner Objects")]
    [SerializeField] private GameObject leftUpCorner;
    [SerializeField] private GameObject rightBottomCorner;

    private Vector3 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }

    private void Start() => StartInit();
    private void Update() => UpdateInit();

    private void StartInit()
    {
        ButtonsActivator();
    }
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
        if (Pos.x <= leftUpCorner.transform.position.x && Pos.y >= leftUpCorner.transform.position.y)
        {
            rightButton.gameObject.SetActive(true);
            downButton.gameObject.SetActive(true);
            print("third");
        }
        
        else if (Pos.x <= leftUpCorner.transform.position.x)
        {
            rightButton.gameObject.SetActive(true);
            upButton.gameObject.SetActive(true);
            downButton.gameObject.SetActive(true);
            print("first");
        }

        else if (Pos.y >= leftUpCorner.transform.position.y)
        {
            rightButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
            downButton.gameObject.SetActive(true);
            print("second");
        }
        
        if (Pos.x >= rightBottomCorner.transform.position.x && Pos.y <= rightBottomCorner.transform.position.y)
        {
            upButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
            print("last");
        }
        
        else if (Pos.x >= rightBottomCorner.transform.position.x)
        {
            upButton.gameObject.SetActive(true);
            downButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
            print("fourth");
        }

        else if (Pos.y <= rightBottomCorner.transform.position.y)
        {
            upButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(true);
            leftButton.gameObject.SetActive(true);
            print("fifth");
        }
    }
    #endregion
}