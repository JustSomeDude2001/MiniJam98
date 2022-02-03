using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUpgradeableStat : UpgradeableStat
{
    public int cost;
    public override bool CanUpgrade()
    {
        if (Player.money < cost) {
            return false;
        }
        if (!Unlocked()) {
            return false;
        }
        return true;
    }

    public override int GetCost()
    {
        return cost;
    }

    public override void Upgrade()
    {
        Player.money -= cost;
        nextLevel++;
    }
}
