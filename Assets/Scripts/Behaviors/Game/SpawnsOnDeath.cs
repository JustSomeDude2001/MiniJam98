using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for mines (explosive traps, not mineable) spawning after walls destroyed.
/// </summary>
public class SpawnsOnDeath : MonoBehaviour
{
    public GameObject spawnedObject;

    public Stat baseSpawnChance;

    private void OnDestroy() {
        // Preventing spawns after game-over.
        if (!Player.isAlive) {
            return;
        }
        if (baseSpawnChance.GetValue() > Random.Range(0f, 1f)) 
            Instantiate(spawnedObject, transform.position, Quaternion.identity);
    }
}
