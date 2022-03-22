using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Upgrade script only allows player 
/// </summary>
public class MetaUpgrade : MonoBehaviour
{
    public MetaUpgradeableStat stat;

    public int level;

    public AudioSource audioSource;
    public AudioClip onSuccessSound;
    
    public bool IsPurchased() {
        return level <= stat.GetCurrentLevel();
    }

    public bool IsAvailable() {
        if (level - 1 != stat.GetCurrentLevel()) {
            return false;
        }
        return stat.Unlocked();
    }

    public bool CanUpgrade() {
        return (!IsPurchased()) && IsAvailable() && (GetCost() <= Player.metaMoney);
    }

    public int GetCost() {
        return stat.GetCost();
    }

    public void TryUpgrade() {
        if (CanUpgrade()) {
            if (audioSource != null)
            {
                audioSource.clip = onSuccessSound;
                audioSource.Play();
            }
            stat.Upgrade();
        }
    }
}
