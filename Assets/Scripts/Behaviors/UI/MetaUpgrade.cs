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
    }

    public bool TryUpgrade() {
        if (CanUpgrade()) {
            Upgrade();
            return true;
        }
        return false;
    }
}
