using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public AudioSource audioSource;
    public AudioClip onMiningSound;
    public AudioClip onMetaPointGainSound;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Check happens on validly finished mining, hence only safe
    /// to grand rewardOnDestroy here.
    /// </summary>
    private void CheckDepletion() {
        if (size <= 0) {
            Player.money += rewardOnDestroy;
            Player.moneyAllTime += rewardOnDestroy;
            Destructible destructible = GetComponent<Destructible>();
            if (destructible != null) {
                destructible.Heal(-destructible.GetMaxHealth());
            } 
            else
            {
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
        Player.moneyAllTime += rewardOnHit;
        if (Random.Range(0.0f, 1.0f) <= metaChance)
        {
            audioSource.clip = onMetaPointGainSound;
            audioSource.Play();
            Player.metaMoney++;
        }

        if (!audioSource.isPlaying) {
            audioSource.clip = onMiningSound;
            audioSource.Play();
        }
        CheckDepletion();
    }
}
