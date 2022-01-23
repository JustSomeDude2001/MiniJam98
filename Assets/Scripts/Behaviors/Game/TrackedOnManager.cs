using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedOnManager : MonoBehaviour
{
    public BoardManager manager;

    public float coefficientOnDestroy;

    public void SetManager(BoardManager manager, float coefficientOnDestroy) {
        this.manager = manager;
        manager.amount++;
        this.coefficientOnDestroy = coefficientOnDestroy;
    }

    private void OnDestroy() {
        manager.amount--;
        manager.spawnCooldownMultipliers *= coefficientOnDestroy;
    }
}
