using DG.Tweening;
using UnityEngine;

public class SealCollision : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    
    [Header("About Duration: ")]
    [SerializeField] private float sealDestroyDur;
    [SerializeField] private float recoilDur;
    [Space]
    
    [Header("Objects: ")]
    [SerializeField] private GameObject lastPos;

    private void Start() => StartInit();

    private void StartInit()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DestroyArea"))
            Destroy(gameObject, sealDestroyDur);
        else if (col.CompareTag("PlayArea"))
            lastPos = col.gameObject;

        else
        {
            if(lastPos is null) return;
            transform.DOMove(lastPos.transform.position, recoilDur);
            _playerMovement.canMove = false;
            _playerMovement.IsStop();
        }
    }
}