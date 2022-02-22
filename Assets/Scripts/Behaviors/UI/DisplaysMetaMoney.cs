using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysMetaMoney : MonoBehaviour
{
    TextMeshProUGUI selfText;
    
    private void Start() {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        selfText.text = Player.metaMoney.ToString() + "<sprite index=3>";
    }
}
