using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsCurrency : MonoBehaviour
{
    public GameObject coreCoin;
    public GameObject metaCoin;

    public float dispersionForce;

    Vector3 getRandomDirectedImpulse()
    {
        return dispersionForce * Random.insideUnitCircle.normalized;
    }
    
    public void DropCoreCoin(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            var targetCoin = GameObject.Instantiate(coreCoin, transform.position, Quaternion.identity);
            Rigidbody2D rb = targetCoin.GetComponent<Rigidbody2D>();
            rb.AddForce(getRandomDirectedImpulse(), ForceMode2D.Impulse);
        }
    }

    public void DropMetaCoin(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            var targetCoin = GameObject.Instantiate(metaCoin, transform.position, Quaternion.identity);
            Rigidbody2D rb = targetCoin.GetComponent<Rigidbody2D>();
            rb.AddForce(getRandomDirectedImpulse(), ForceMode2D.Impulse);
        }
    }
}
