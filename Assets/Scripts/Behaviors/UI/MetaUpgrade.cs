using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaUpgrade : MonoBehaviour
{
    public string modifierName;
    public List <float> values;
    public List <int> costs;

    [HideInInspector]
    public int currentLevel;
    
    private void Refresh() {
        currentLevel = Player.GetLevel(modifierName);
    }
    
    public int GetCost() {
        Refresh();
        if (currentLevel + 1 >= values.Count) {
            return 999;
        }
        return costs[currentLevel + 1];
    }

    public bool CanUpgrade() {
        Refresh();
        if (currentLevel + 1 >= values.Count) {
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
        Player.metaMoney -= GetCost();
        currentLevel++;
        Player.SetLevel(modifierName, currentLevel);
        Player.SetModifier(modifierName, values[currentLevel]);
    }

    // Done just in case some modifiers behave in a special way.
    private void OnDestroy() {
        Player.SetModifier(modifierName, values[currentLevel]);
    }
}
