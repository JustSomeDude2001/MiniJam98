using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysMetaMoney : MonoBehaviour
{
    TextMeshPro selfText;
    
    private void Start() {
        selfText = GetComponent<TextMeshPro>();
    }

    private void Update() {
        selfText.text = Player.metaMoney.ToString();
    }
}
