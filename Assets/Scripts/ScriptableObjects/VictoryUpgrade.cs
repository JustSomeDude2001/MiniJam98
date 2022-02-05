using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "VictoryUpgrade")]
public class VictoryUpgrade : MetaUpgradeableStat
{
    [Tooltip("Which scene to load on first upgrade.")]
    public string victoryScene;
    public override void Upgrade() {
        SceneManager.LoadScene(victoryScene, LoadSceneMode.Single);
    }
}
