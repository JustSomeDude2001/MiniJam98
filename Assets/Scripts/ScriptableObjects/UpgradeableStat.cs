using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeableStat : Stat
{
    [Tooltip("If upgrade has prerequisites, add the stats that are prerequisites in here. Add a value for each item here in Prerequisite Upgrade Amounts list.")]
    public List <UpgradeableStat> prerequisiteUpgrades;
    [Tooltip("For every prerequisite stat, add the amount of upgrades that need to be done on that stat, e.g. which level the stat needs to be. At start all stats are level 0.")]
    public List <int> prerequisiteUpgradeAmounts;

    [Tooltip("All upgraded values, from 1st upgrade to last, that will override the base value. If this is a meta stat, amount needs to match amount of costs list objects")]
    public List <float> upgradedValues;
    protected int nextLevel;

    private void OnEnable() {
        Initialize();
    }

    public virtual void Initialize() {
        ResetToInitial();
    }

    public virtual void ResetToInitial() {
        nextLevel = 0;
    }

    public int GetCurrentLevel() {
        return nextLevel;
    }
    public override float GetValue() {
        if (nextLevel == 0) {
            return baseValue;
        }
        return upgradedValues[nextLevel - 1];
    }
    public bool Unlocked() {
        for (int i = 0; i < prerequisiteUpgrades.Count; i++) {
            if (prerequisiteUpgrades[i].GetCurrentLevel() < prerequisiteUpgradeAmounts[i]) {
                return false;
            }
        }
        return true;
    }
    public bool IsMaxLevel() {
        return nextLevel == upgradedValues.Count;
    }
    public abstract bool CanUpgrade();
    public abstract void Upgrade();
    public abstract int GetCost();
}
