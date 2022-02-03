using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUpgrade : MonoBehaviour
{
    public TempUpgradeableStat stat;

    public int GetCost() {
        return stat.GetCost();
    }

    public bool IsMaxLevel() {
        return stat.IsMaxLevel();
    }

    public bool IsAvailable() {
        return stat.Unlocked();
    }

    public bool CanUpgrade() {
        return stat.CanUpgrade();
    }

    private void Upgrade() {
        stat.Upgrade();
    }

    public void TryUpgrade() {
        if (CanUpgrade()) {
            Upgrade();
        }
    }
}
