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

    public bool IsPurchased() {
        return level < stat.GetCurrentLevel();
    }

    public bool IsAvailable() {
        return stat.Unlocked();
    }

    public int GetCost() {
        return stat.GetCost();
    }

    public void TryUpgrade() {
        if (stat.CanUpgrade()) {
            stat.Upgrade();
        }
    }
}
