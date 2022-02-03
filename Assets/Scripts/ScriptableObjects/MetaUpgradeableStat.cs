using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MetaUpgradeableStat")]
public class MetaUpgradeableStat : UpgradeableStat
{
    public List <int> costs;

    public override bool CanUpgrade()
    {
        if (GetCost() > Player.metaMoney) {
            return false;
        }
        if (!Unlocked()) {
            return false;
        }
        if (nextLevel == costs.Count) {
            return false;
        }

        return true;
    }

    public override int GetCost()
    {
        return costs[nextLevel];
    }

    public override void Upgrade()
    {
        Player.metaMoney -= GetCost();
        nextLevel++;
    }
}
