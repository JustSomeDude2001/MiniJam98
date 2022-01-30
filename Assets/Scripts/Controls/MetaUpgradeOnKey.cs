using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MetaUpgradeOnKey : MonoBehaviour
{
    [HideInInspector]
    static public MetaUpgrade currentUpgrade;

    public void OnMetaUpgrade(InputAction.CallbackContext context) {
        // Fuck unity event system I fucking hate this bloody piece of shit.
        if (context.started != true) {
            return;
        }
        if (currentUpgrade == null) {
            return;
        }
        if (currentUpgrade.CanUpgrade()) {
            currentUpgrade.Upgrade();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        currentUpgrade = other.GetComponent<MetaUpgrade>();
    }

    private void OnTriggerExit2D(Collider2D other) {
        currentUpgrade = null;
    }
}
