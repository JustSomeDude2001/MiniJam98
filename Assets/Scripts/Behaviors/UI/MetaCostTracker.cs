using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetaCostTracker : MonoBehaviour
{
    public MetaUpgrade tracked;

    TextMeshPro display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = tracked.GetCost().ToString();
        if (tracked.isPurchased) {
            display.text = "SOLD";
        } else if (tracked.isAvailable == false) {
            display.text = "LOCKED";
        }
    }
}
