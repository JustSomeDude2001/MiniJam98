using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TempUpgradeableStat")]
public class TempUpgradeableStat : UpgradeableStat
{
    [System.NonSerialized]
    public static List <TempUpgradeableStat> knownTempUpgrades = new List<TempUpgradeableStat>();

    [Tooltip("Costs of all the upgrades of this stat. Amount must match amount of values.")]
    public List <int> costs;

    public override void Initialize()
    {
        knownTempUpgrades.Add(this);
        ResetToInitial();
    }

    public override bool CanUpgrade()
    {
        if (Player.money < costs[nextLevel]) {
            return false;
        }
        if (GetCurrentLevel() >= upgradedValues.Count)
        {
            return false;
        }
        if (!Unlocked()) {
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
        Player.money -= costs[nextLevel];
        nextLevel++;
    }
}
