using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPointsOnDeath : MonoBehaviour
{
    public DropsCurrency currencySpawner;
    
    public int reward = 0;
    public Destructible destructible;

    private bool rewardDelivered = false;
    
    private void Update()
    {
        if (destructible.dying && !rewardDelivered)
        {
            currencySpawner.DropMetaCoin(reward);
            rewardDelivered = true;
        }
    }
}
