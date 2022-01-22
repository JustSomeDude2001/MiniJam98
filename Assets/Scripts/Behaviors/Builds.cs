using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builds : MonoBehaviour
{
    public GameObject building;
    public int cost;

    public void Build() {
        Instantiate(building, transform.position, Quaternion.identity);
    }
}
