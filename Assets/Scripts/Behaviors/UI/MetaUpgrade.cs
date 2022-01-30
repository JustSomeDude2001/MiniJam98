using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaUpgrade : MonoBehaviour
{
    public string modifierName;
    public int level;
    public float value;
    public int cost;

    public List<string> prerequisiteLevelNames = new List<string>();
    public List<int> prerequisiteLevelValues = new List<int>();
    
    [HideInInspector]
    public bool isAvailable = false;
    [HideInInspector]
    public bool isPurchased = false;

    private void Refresh() {
        isAvailable = true;
        if (Player.GetLevel(modifierName) >= level) {
            isAvailable = false;
            isPurchased = true;
            return;
        }
        for (int i = 0; i < prerequisiteLevelNames.Count; i++) {
            if (Player.GetLevel(prerequisiteLevelNames[i]) < prerequisiteLevelValues[i]) {
                isAvailable = false;
                break;
            }
        }
    }
    
    public int GetCost() {
        Refresh();
        return cost;
    }

    public bool CanUpgrade() {
        Refresh();
        if (!isAvailable) {
            return false;
        }
        if (Player.GetLevel(modifierName) >= level) {
            return false;
        }
        if (GetCost() > Player.metaMoney) {
            return false;
        }
        return true;
    }

    public void Upgrade() {
        if (!CanUpgrade()) {
            return;
        }
        isPurchased = true;
        Player.metaMoney -= GetCost();
        Player.SetLevel(modifierName, level);
        Player.SetModifier(modifierName, value);
    }

    private void Start() {
        Refresh();
    }

}
