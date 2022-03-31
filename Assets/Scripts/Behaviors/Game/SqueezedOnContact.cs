using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SqueezedOnContact : MonoBehaviour
{
    public float ySqueeze;
    public float ySqueezeDuration;
    public GameObject target;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            target.transform.DOScaleY(ySqueeze, ySqueezeDuration);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            target.transform.DOScaleY(1, ySqueezeDuration);
    }
}
