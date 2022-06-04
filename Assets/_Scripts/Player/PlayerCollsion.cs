using DG.Tweening;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    public GameObject lastPos;
    private PlayerMovement _playerMovement;
    private SelectManager _selectManager;

    [Header("About Duration: "), Space]
    [SerializeField] private float penguinDestroyDur;
    [SerializeField] private float recoilDur;

    private Vector2 Pos
    {
        get => transform.position;
        set => transform.position = value;
    }
    private void Start() => StartInit();
    private void StartInit()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _selectManager = GameObject.Find("SelectManager").GetComponent<SelectManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayArea"))
        {
            lastPos = col.gameObject;
        }

        if (col.CompareTag(gameObject.tag) && col.gameObject.layer == gameObject.layer)
        {
            GameManager.Instance.score += 0.5f;
            if (GameManager.Instance.activePenguin.Contains(col.gameObject))
                GameManager.Instance.activePenguin.Remove(col.gameObject);
            if (GameManager.Instance.activePenguin.Contains(gameObject))
                GameManager.Instance.activePenguin.Remove(gameObject);
            Destroy(col.gameObject, penguinDestroyDur);
            Destroy(gameObject, penguinDestroyDur);
            _selectManager.selectedGo = null;
        }

        if ((col.CompareTag(gameObject.tag) && col.gameObject.layer != gameObject.layer) || col.CompareTag("Seal") || col.CompareTag("Obstacle"))
        {
            if(lastPos == null) return;
            transform.DOMove(lastPos.transform.position, recoilDur);
            _playerMovement.canMove = false;
            _playerMovement.IsStop();
        }

        if (col.CompareTag("DestroyArea"))
        {
            if (GameManager.Instance.activePenguin.Contains(gameObject))
                GameManager.Instance.activePenguin.Remove(gameObject);
            Destroy(gameObject, penguinDestroyDur);
            _selectManager.selectedGo = null;
        }
    }
}
