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

    private float MatchPenguin
    {
        get => GameManager.Instance.matchedPenguin;
        set => GameManager.Instance.matchedPenguin = value;
    }
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
            MatchPenguin += 0.5f;
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
            Destroy(gameObject, penguinDestroyDur);
            _selectManager.selectedGo = null;
        }
    }
}
