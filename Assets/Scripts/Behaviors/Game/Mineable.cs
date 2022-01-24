using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineable : MonoBehaviour
{
    /// <summary>
    /// Amount of mining cycles on mine.
    /// </summary>
    public int size;

    /// <summary>
    /// How much money given per hit(?)
    /// </summary>
    public int rewardOnHit;

    /// <summary>
    /// How much money given on destruction of node.
    /// </summary>
    public int rewardOnDestroy;

    /// <summary>
    /// Chance of meta point dropping. TO-DO.
    /// </summary>
    public float metaChance;

    /// <summary>
    /// Check happens on validly finished mining, hence only safe
    /// to grand rewardOnDestroy here.
    /// </summary>
    private void CheckDepletion() {
        if (size <= 0) {
            Player.money += rewardOnDestroy;
            Destructible destructible = GetComponent<Destructible>();
            if (destructible != null) {
                destructible.Heal(-destructible.healthMax);
            } else {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Mine a mineable object.
    /// </summary>
    public void Mine() {
        if (size <= 0) {
            return;
        }
        size--;
        Player.money += rewardOnHit;
        if (Random.Range(0.0f, 1.0f) <= metaChance) {
            Player.metaMoney++;
        }
        CheckDepletion();
    }
}
