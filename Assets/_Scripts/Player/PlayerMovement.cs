using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;

    [Header("Booleans")] 
    public bool canMove;
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


    private bool Stopper => GetComponent<Rigidbody2D>().velocity.x is <= 0 and <= 0;
    private Vector3 Pos => transform.position;
    private void Update() => UpdateInit();
    
    private void UpdateInit()
    {
        ButtonChecker();
    }
    
    #region Movement Button

    public void IsStop()
    {
        if (!Stopper) return;
        _goDown = false;
        _goLeft = false;
        _goRight = false;
        _goUp = false;
    }
    private void ButtonChecker()
    {
        if(!canMove) return;
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
        canMove = true;
        AllButtonInActive();
    }

    public void RightButtonMovement()
    {
        _goRight = true;
        canMove = true;
        AllButtonInActive();
    }

    public void UpButtonMovement()
    {
        _goUp = true;
        canMove = true;
        AllButtonInActive();
    }

    public void DownButtonMovement()
    {
        _goDown = true;
        canMove = true;
        AllButtonInActive();
    }

    #endregion

    #region ButtonsActiveChanger

    public void AllButtonInActive()
    {
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        upButton.gameObject.SetActive(false);
        downButton.gameObject.SetActive(false);
    }

    public void ButtonsActivator()
    {
        
        rightButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        downButton.gameObject.SetActive(true);
        upButton.gameObject.SetActive(true);
        
        if (Pos.x <= leftUpCorner.transform.position.x && Pos.y >= leftUpCorner.transform.position.y)
        {
            upButton.gameObject.SetActive(false);
            leftButton.gameObject.SetActive(false);
        }
        
        else if (Pos.x <= leftUpCorner.transform.position.x)
        {
            leftButton.gameObject.SetActive(false);
        }

        else if (Pos.y >= leftUpCorner.transform.position.y)
        {
            upButton.gameObject.SetActive(false);
        }
        
        if (Pos.x >= rightBottomCorner.transform.position.x && Pos.y <= rightBottomCorner.transform.position.y)
        {
            downButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(false);
        }
        
        else if (Pos.x >= rightBottomCorner.transform.position.x)
        {
            rightButton.gameObject.SetActive(false);
        }

        else if (Pos.y <= rightBottomCorner.transform.position.y)
        {
            downButton.gameObject.SetActive(false);
        }
    }
    #endregion
}