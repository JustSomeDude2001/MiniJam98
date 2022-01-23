using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A property of a cursor to be able to upgrade items.
/// </summary>
public class Upgrades : MonoBehaviour
{
    public bool CanUpgrade() {
        GameObject targetObject = GridMatrix.GetObject(GridMatrix.selfGrid.WorldToCell(transform.position));
        
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

    public void Upgrade() {
        if (!CanUpgrade()) {
            return;
        }

        Upgradeable upgrade = GridMatrix.GetObject(GridMatrix.selfGrid.WorldToCell(transform.position)).GetComponent<Upgradeable>();

        Player.money -= upgrade.cost;

        GridMatrix.Destroy(CursorTracker.cursorPos);
        GridMatrix.Build(CursorTracker.cursorPos, Instantiate(upgrade.nextUpgrade, transform.position, Quaternion.identity));
    }
}
