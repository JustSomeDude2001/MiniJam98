using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeableStat : Stat
{
    public List <float> upgradedValues;
    public List <UpgradeableStat> prerequisiteUpgrades;
    public List <int> prerequisiteUpgradeLevels;
    protected int nextLevel;
    
    private void OnEnable() {
        nextLevel = 0;
    }
    
    public int GetCurrentLevel() {
        return nextLevel;
    }
    public override float GetValue() {
        if (nextLevel == 0) {
            return baseValue;
        }
        return upgradedValues[nextLevel];
    }
    public bool Unlocked() {
        for (int i = 0; i < prerequisiteUpgrades.Count; i++) {
            if (prerequisiteUpgrades[i].GetCurrentLevel() < prerequisiteUpgradeLevels[i]) {
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
