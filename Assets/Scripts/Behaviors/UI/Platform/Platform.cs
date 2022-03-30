using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [HideInInspector] public bool isOnPlatform;

    public PlatformSide frontSide;
    public PlatformSide backSide;

    SpriteRenderer PlayerRenderer;

    private bool enteredFromBack = false;
    private bool enteredFromFront = false;

    private void Start()
    {
        if (PlayerRenderer == null)
        {
            PlayerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            isOnPlatform = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isOnPlatform = false;
            enteredFromBack = false;
            enteredFromFront = false;
            resetRenderer();
        }
    }

    void resetRenderer()
    {
        PlayerRenderer.sortingOrder = 0;
        PlayerRenderer.transform.DOScale(1f, 0.1f);
    }

    void putOnFront()
    {
        PlayerRenderer.sortingOrder = 1;
        PlayerRenderer.transform.DOScale(1.2f, 0.1f);
    }

    void putOnBack()
    {
        PlayerRenderer.sortingOrder = -1;
        PlayerRenderer.transform.DOScale(1f, 0.1f);
    }

    private void Update()
    {
        if (!isOnPlatform)
        {
            return;
        }

        if (!enteredFromBack && !enteredFromFront)
        {
            if (backSide.hadPlayer && !frontSide.hadPlayer)
            {
                enteredFromBack = true;
            }

            if (frontSide.hadPlayer && !backSide.hadPlayer)
            {
                enteredFromFront = true;
            }
        }

        if (enteredFromBack)
        {
            if (frontSide.hadPlayer)
            {
                putOnFront();
            }
            else
            {
                putOnBack();
            }
        }

        if (enteredFromFront)
        {
            putOnFront();
        }
    }
}
