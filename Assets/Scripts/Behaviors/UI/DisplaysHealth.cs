using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysHealth : MonoBehaviour
{
    public Destructible targetEntity;
    public TextMeshProUGUI display;
    
    // Update is called once per frame
    void Update()
    {
        display.text = "Health:" + Math.Max(targetEntity.GetHealth(), 0).ToString();
    }
}
