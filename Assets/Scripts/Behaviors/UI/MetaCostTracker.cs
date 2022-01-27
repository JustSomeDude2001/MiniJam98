using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MetaCostTracker : MonoBehaviour
{
    public MetaUpgrade tracked;
    public Color positiveColor;
    public Color negativeColor;

    TextMeshProUGUI display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = tracked.cost.ToString();
        if (tracked.CanUpgrade()) {
            display.color = positiveColor;
        } else {
            display.color = negativeColor;
        }
    }
}
