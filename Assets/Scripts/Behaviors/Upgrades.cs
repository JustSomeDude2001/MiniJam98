using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A property of a cursor to be able to upgrade items.
/// </summary>
public class Upgrades : MonoBehaviour
{
    public float cooldown;    

    float lastUpgrade = -1;

    public bool CanUpgrade() {
        GameObject targetObject = GridMatrix.GetObject(GridMatrix.selfGrid.WorldToCell(transform.position));
        
        if (Time.time - lastUpgrade <= cooldown) {
            return false;
        }

        if (targetObject == null) {
            return false;
        }

        Upgradeable upgrade = targetObject.GetComponent<Upgradeable>();
        
        if (upgrade == null) {
            return false;
        }

        if (upgrade.timeUntilCanUpgrade > 0f) {
            return false;
        }

        if (upgrade.cost > Player.money) {
            return false;
        }

        return true;
    }

    Builds selfBuilder;

    public void Upgrade() {
        if (selfBuilder == null) {
            selfBuilder = GetComponent <Builds>();
        }
        if (!CanUpgrade()) {
            return;
        }
        selfBuilder.lastBuild = Time.time;
        Upgradeable upgrade = GridMatrix.GetObject(GridMatrix.selfGrid.WorldToCell(transform.position)).GetComponent<Upgradeable>();

        GameObject result = upgrade.nextUpgrade;

        Player.money -= upgrade.cost;

        Instantiate(result, transform.position, Quaternion.identity);
        Destroy(upgrade.gameObject);
        lastUpgrade = Time.time;
    }
}
