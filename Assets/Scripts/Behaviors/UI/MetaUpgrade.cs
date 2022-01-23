using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaUpgrade : MonoBehaviour
{
    public string modifierName;
    public float multiplier = 1;
    public float offset = 0;
    public int cost;
    public float costProgression;
    public int maxLevel;
    public int currentLevel;

    private void Start() {
        currentLevel = Player.GetLevel(modifierName);
        for (int i = 0; i < currentLevel; i++) {
            cost = (int)(cost * costProgression);
        }
    }
    
    public bool CanUpgrade() {
        if (currentLevel >= maxLevel) {
            return false;
        }
        if (Player.metaMoney < cost) {
            return false;
        }

        return true;
    }

    public void Upgrade() {
        if (!CanUpgrade()) {
            return;
        }
        Player.metaMoney -= cost;
        float currentMod = Player.GetModifier(modifierName);
        currentMod *= multiplier;
        currentMod += offset;
        cost = (int)(cost * costProgression);
        currentLevel++;
        Player.SetLevel(modifierName, currentLevel);
        Player.SetModifier(modifierName, currentMod);
    }

}
