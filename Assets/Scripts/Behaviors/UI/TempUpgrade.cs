using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TempUpgrade : MonoBehaviour
{
    [HideInInspector]
    public bool isUnlocked = false;

    public TempUpgradeableStat stat;

    public List<TextMeshProUGUI> textToEnable;

    Button selfButton;
    Image selfImage;
    private List<Image> childImages;

    public AudioClip onSuccessSound;
    public AudioSource audioSource;
    
    private void Start() {
        selfButton = GetComponent<Button>();
        selfImage = GetComponent<Image>();
        childImages = new List<Image>(GetComponentsInChildren<Image>());
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Update() {
        if (!isUnlocked) {
            if (IsAvailable()) {
                isUnlocked = true;
                selfImage.enabled = true;
                selfButton.enabled = true;
                for (int i = 0; i < textToEnable.Count; i++) {
                    textToEnable[i].enabled = true;
                }
                for (int i = 0; i < childImages.Count; i++)
                {
                    childImages[i].enabled = true;
                }
            }
        }
    }

    public int GetLevel() {
        return stat.GetCurrentLevel() + 1;
    }

    public int GetCost() {
        return stat.GetCost();
    }

    public bool IsMaxLevel() {
        return stat.IsMaxLevel();
    }

    public bool IsAvailable() {
        return stat.Unlocked();
    }

    public bool CanUpgrade() {
        return stat.CanUpgrade();
    }

    private void Upgrade() {
        stat.Upgrade();
    }

    public void TryUpgrade() {
        if (CanUpgrade()) {
            if (audioSource != null)
            {
                audioSource.clip = onSuccessSound;
                audioSource.Play();
            }
            Upgrade();
        }
    }
}
