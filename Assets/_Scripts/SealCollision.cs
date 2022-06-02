using System;
using UnityEngine;

public class SealCollision : MonoBehaviour
{
    [SerializeField] private float sealDestroyDur;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DestroyArea"))
            Destroy(gameObject, sealDestroyDur);
    }
}