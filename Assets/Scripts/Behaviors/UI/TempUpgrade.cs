using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempUpgrade : MonoBehaviour
{
    public string modifierName;
    public List<float> modifier;
    public List<int> cost;

    public List <string> requirementNames;
    public List <int> requirementLevels;


    private void Start() {
        if (!Player.IsTempUpgrade(modifierName)) {
            modifierName = Player.ToTemp(modifierName);
        }
    }

    public int GetNextLevel() {
        return Player.GetLevel(modifierName) + 1;
    }

    public int GetCost() {
        return cost[GetNextLevel()];
    }

    public bool IsMaxLevel() {
        return Player.GetLevel(modifierName) >= modifier.Count - 1;
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
        if (!IsMaxLevel() && IsAvailable() && cost[GetNextLevel()] <= Player.money) {
            return true;
        }
        return false;
    }

    private void Upgrade() {
        int nextLevel = GetNextLevel();
        Player.SetLevel(modifierName, nextLevel);
        Player.SetModifier(modifierName, modifier[nextLevel]);
        Debug.Log(Player.GetModifier(modifierName));
        Player.money -= cost[nextLevel];
    }

    public void TryUpgrade() {
        if (CanUpgrade()) {
            Upgrade();
        }
    }
}
