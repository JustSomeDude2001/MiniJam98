using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager to control spawnrates of objects.
/// </summary>
public class BoardManager : MonoBehaviour
{
    GridMatrix matrix;

    public GameObject targetObject;
    public int amountLimit;
    public int amount;
    public List<float> timeToSpawn;
    public int moneyToSpawn;
    public bool canSpawn;

    public float spawnCooldownMultipliers;

    public bool spawnsOnEdge;
    public float speedupCoefficient;

    private void Start() {
        matrix = GetComponent<GridMatrix>();
    }

    float lastSpawn = 0;

    private void Update() {
        float timeAfterSpawn = Time.time - lastSpawn;

            if (amount >= amountLimit) {
                return;
            }

            if (Player.money >= moneyToSpawn) {
                canSpawn = true;
            }

            if (!canSpawn) {
                return;
            }

            if (timeAfterSpawn < timeToSpawn[amount] * spawnCooldownMultipliers) {
                return;
            }

            GameObject newObject;

            if (!spawnsOnEdge) {
                Vector3Int newPos = GridMatrix.GetRandomFreePos();
                if (newPos == null) {
                    return;
                }
                newObject = Instantiate(targetObject, GridMatrix.selfGrid.CellToWorld(newPos), Quaternion.identity);
            } else {
                newObject = Instantiate(targetObject, GridMatrix.GetRandomEdgePos(), Quaternion.identity);
            }
            lastSpawn = Time.time;
            TrackedOnManager tracker = newObject.AddComponent<TrackedOnManager>();
            tracker.SetManager(this, speedupCoefficient);
    }

}
