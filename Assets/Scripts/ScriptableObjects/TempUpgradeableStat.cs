using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TempUpgradeableStat")]
public class TempUpgradeableStat : UpgradeableStat
{
    [System.NonSerialized]
    public static List <TempUpgradeableStat> knownTempUpgrades = new List<TempUpgradeableStat>();
    public int upgradeCost;

    public override void Initialize()
    {
        knownTempUpgrades.Add(this);
        ResetToInitial();
    }

    public override bool CanUpgrade()
    {
        if (Player.money < upgradeCost) {
            return false;
        }
        if (!Unlocked()) {
            return false;
        }
        return true;
    }

    public override int GetCost()
    {
        return upgradeCost;
    }

    public override void Upgrade()
    {
        Player.money -= upgradeCost;
        nextLevel++;
    }
}
