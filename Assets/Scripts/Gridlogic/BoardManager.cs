using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    GridMatrix matrix;

    public List <GameObject> minesPossible;

    public List <int> minesAmountLimit;
    public List <int> minesAmount;
    public List <List<float> > minesTimeToSpawn;

    public List <GameObject> enemiesPossible;
    public List <int> enemiesAmountLimit;
    public List <int> enemiesAmount;
    public List <List<float> > enemiesTimeToSpawn;

    public List <float> enemiesSpawnCooldownMultipliers;

    private void Start() {
        matrix = GetComponent<GridMatrix>();
    }

    float lastMineSpawn = 0;
    float lastEnemySpawn = 0;

    private void Update() {
        float timeAfterMineSpawn = Time.time - lastMineSpawn;
        float timeAfterEnemySpawn = Time.time - lastEnemySpawn;
    }
}
