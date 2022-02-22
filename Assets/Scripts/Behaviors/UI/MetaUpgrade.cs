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
        if (!CanUpgrade()) {
            return;
        }
        if (stat.CanUpgrade()) {
            stat.Upgrade();
        }
    }
}
