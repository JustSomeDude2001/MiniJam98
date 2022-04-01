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
    [HideInInspector]
    public int amount = 0;
    public List<float> timeToSpawn;
    public int moneyToSpawn;
    public bool canSpawn;

    /// <summary>
    /// Initial cooldown multiplier
    /// </summary>
    [HideInInspector]
    public float currentCooldownMultiplier = 1;

    public bool spawnsOnEdge;
    public float speedupCoefficient;

    private void Start() {
        matrix = GetComponent<GridMatrix>();
    }

    float lastSpawn = 0;

    private void Update() {
        float timeAfterSpawn = Time.time - lastSpawn;

            if (amount >= amountLimit) {
                lastSpawn = Time.time;
                return;
            }

            if (Player.moneyAllTime >= moneyToSpawn) {
                canSpawn = true;
            }

            if (!canSpawn) {
                lastSpawn = Time.time;
                return;
            }

            if (timeAfterSpawn < timeToSpawn[amount] * currentCooldownMultiplier) {
                //lastSpawn = Time.time;
                return;
            }

            GameObject newObject;

            if (!spawnsOnEdge) {
                Vector3Int newPos = GridMatrix.GetRandomFreePos();
                if (newPos == null) {
                    lastSpawn = Time.time;
                    return;
                }
                newObject = Instantiate(targetObject, GridMatrix.selfGrid.CellToWorld(newPos) + GridMatrix.selfGrid.cellSize / 2f, Quaternion.identity);
            } else
            {
                Vector3 newPosition = GridMatrix.GetRandomEdgePos();
                while ((newPosition - Player.playerPos).magnitude < 1) // TO-DO Come up with something smart later
                {
                    newPosition = GridMatrix.GetRandomEdgePos();
                }
                newObject = Instantiate(targetObject, newPosition, Quaternion.identity);
            }
            lastSpawn = Time.time;
            TrackedOnManager tracker = newObject.AddComponent<TrackedOnManager>();
            tracker.SetManager(this, speedupCoefficient);
    }

}
