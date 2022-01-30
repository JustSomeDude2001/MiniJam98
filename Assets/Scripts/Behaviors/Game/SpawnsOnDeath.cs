using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for mines (explosive traps, not mineable) spawning after walls destroyed.
/// </summary>
public class SpawnsOnDeath : MonoBehaviour
{
    public GameObject spawnedObject;

    public float baseSpawnChance = 1;

    private void Start() {
        if (tag == "Wall") {
            //Check required to prevent defaulting to 100% chance of spawn.
            if (Player.GetLevel("mineSpawnChance") == 0) {
                baseSpawnChance = 0;
            } else {
                baseSpawnChance *= Player.GetModifier("mineSpawnChance");
            }
        }
    }

    private void OnDestroy() {
        // Preventing spawns after game-over.
        if (!Player.isAlive) {
            return;
        }
        if (baseSpawnChance > Random.Range(0f, 1f)) 
            Instantiate(spawnedObject, transform.position, Quaternion.identity);
    }
}
