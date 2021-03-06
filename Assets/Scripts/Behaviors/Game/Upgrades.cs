using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A property of a cursor to be able to upgrade buildings during core gameplay.
/// </summary>
public class Upgrades : MonoBehaviour
{
    public MetaUpgradeableStat Upgradeability;

    public float cooldown;    

    float lastUpgrade = -1;

    Animator selfAnimator;

    [HideInInspector]
    public bool isInRadius = false;

    private void Start() {
        selfAnimator = GetComponent<Animator>();
    }

    public bool CanUpgrade() {
        if (!isInRadius) {
            return false;
        }
        if (Upgradeability.GetCurrentLevel() == 0) {
            return false;
        }

        if (Player.isOnPause) {
            return false;
        }

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
    
    private void Update() {
        if (selfAnimator != null) {
            selfAnimator.SetBool("canUpgrade", CanUpgrade());
        }
    }
}
