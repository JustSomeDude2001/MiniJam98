using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSide : MonoBehaviour
{
    public bool hadPlayer;
    public bool hasPlayer;
    
    public Platform platform;
    
    private void Update()
    {
        if (platform.isOnPlatform == false)
        {
            hadPlayer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hadPlayer = true;
            hasPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}
