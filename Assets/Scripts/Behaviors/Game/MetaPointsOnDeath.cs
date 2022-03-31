using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPointsOnDeath : MonoBehaviour
{
    public int reward = 0;
    public AudioClip onMetaPointGainSound;
    public AudioSource audioSource;
    public Destructible destructible;

    private bool rewardDelivered = false;
    
    private void Update()
    {
        if (destructible.dying && !rewardDelivered)
        {
            audioSource.clip = onMetaPointGainSound;
            audioSource.Play();
            Player.metaMoney += reward;
        }
    }
}
