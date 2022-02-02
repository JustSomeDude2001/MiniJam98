using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetaCostTracker : MonoBehaviour
{
    public MetaUpgrade tracked;

    TextMeshPro display;

    public string notUnlockedText = "LOCKED";
    public string purchasedText = "SOLD";

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tracked.IsPurchased()) {
            display.text = purchasedText;
        } else if(!tracked.IsAvailable()) {
            display.text = notUnlockedText;
        } else {
            display.text = tracked.GetCost().ToString();
        }
    }
}
