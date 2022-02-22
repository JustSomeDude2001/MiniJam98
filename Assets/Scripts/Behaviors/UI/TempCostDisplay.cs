using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempCostDisplay : MonoBehaviour
{
    public TempUpgrade tempUpgrade;
    public TextMeshProUGUI text;
    public string maxedOutText;

    private void Update() {
        if (tempUpgrade.IsMaxLevel()) {
            text.text = maxedOutText;
        } else {
            text.text = tempUpgrade.GetCost().ToString() + "<sprite index=4>";
        }
    }
}
