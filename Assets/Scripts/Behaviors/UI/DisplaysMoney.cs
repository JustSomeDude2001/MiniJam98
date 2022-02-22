using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysMoney : MonoBehaviour
{
    TextMeshProUGUI selfText;
    
    private void Start() {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        selfText.text = Player.money.ToString() + "<sprite index=4>";
    }
}
