using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempUpgradeLevelTracker : MonoBehaviour
{
    public Image targetImageObject;
    
    public Sprite unlockedImage;

    public TempUpgradeableStat stat;
    public int level;

    private bool isUnlocked = false;
    
    private void Update()
    {
        if (isUnlocked)
        {
            return;
        }
        if (stat.GetCurrentLevel() >= level)
        {
            isUnlocked = true;
            targetImageObject.sprite = unlockedImage;
        }
    }
}
