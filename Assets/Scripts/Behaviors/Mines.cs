using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    /// <summary>
    /// radius of mining in grid cells.
    /// </summary>
    public float radius;

    /// <summary>
    /// Cooldown between automatic mining actions.
    /// </summary>
    public float miningCooldown;

    public Mineable GetMineableInRadius() {
        for (int k = 0; k < radius; k++) {
            for (int i = -k; i <= k; i++) {
                for (int j = -k; j <= k; j++) {
                    if (Mathf.Abs(i) < k && Mathf.Abs(j) < k) {
                        continue;
                    }
                    if (i * i + j * j > radius * radius) {
                        continue;
                    }
                    Vector3Int target = GridMatrix.selfGrid.WorldToCell(transform.position);
                    target.y += i;
                    target.x += j;
                    GameObject targetObject = GridMatrix.GetObject(target);
                    Debug.Log("Checking Position:" + target.ToString() + " Have: " + (targetObject != null).ToString());
                    if (targetObject != null) {
                        Mineable result = targetObject.GetComponent<Mineable>();
                        if (result == null) {
                            continue;
                        } else {
                            return result;
                        }
                    }
                }
            }
        }
        return null;
    }
    
    float lastMineOperation = -1;
    
    /// <summary>
    /// Will mine nearest (by cell) mineable every time cooldown resets
    /// </summary>
    private void Update() {
        float elapsedTime = Time.time - lastMineOperation;
        if (elapsedTime >= miningCooldown) {
            Mineable target = GetMineableInRadius();
            if (target != null) {
                target.Mine();
                lastMineOperation = Time.time;
            }
        }
    }
}
