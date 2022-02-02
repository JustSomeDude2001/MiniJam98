using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaUpgrade : MonoBehaviour
{
    public string modifierName;
    public float modifier;
    public int cost;
    public int level;

    public List <string> requirementNames;
    public List <int> requirementLevels;

    /// <summary>
    /// Useful if you want temporary upgrades for meta currency.
    /// So not use otherwise.
    /// </summary>
    public bool isTemp = false;

    private void Start() {
        if (isTemp) {
            if (!Player.IsTempUpgrade(modifierName)) {
                modifierName = Player.ToTemp(modifierName);
            }
        }
    }

    public int GetCost() {
        return cost;
    }

    public bool IsPurchased() {
        return Player.GetLevel(modifierName) >= level;
    }

    public bool IsAvailable() {
        for (int i = 0; i < requirementLevels.Count; i++) {
            if (Player.GetLevel(requirementNames[i]) < requirementLevels[i]) {
                return false;
            }
        }
        return true;
    }

    public bool CanUpgrade() {
        if (!IsPurchased() && IsAvailable() && cost <= Player.metaMoney) {
            return true;
        }
        return false;
    }

    private void Upgrade() {
        Player.SetLevel(modifierName, level);
        Player.SetModifier(modifierName, modifier);
        Player.metaMoney -= cost;
        Player.purchasedMetaUpgrade = true;
    }

    public bool TryUpgrade() {
        if (CanUpgrade()) {
            Upgrade();
            return true;
        }
        return false;
    }
}
