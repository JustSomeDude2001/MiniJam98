using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSpriteChooser : MonoBehaviour
{
    public Builds builder;
    public Upgrades upgrader;
    public CursorTracker cursorTracker;
    public Animator cursorAnimator;
    private static readonly int CanBuild = Animator.StringToHash("canBuild");
    private static readonly int CanUpgrade = Animator.StringToHash("CanUpgrade");

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        cursorAnimator.SetBool(CanBuild, builder.CanBuild());
        cursorAnimator.SetBool(CanUpgrade, upgrader.CanUpgrade());
        if (cursorTracker.isOutOfBounds)
            cursorAnimator.SetBool(CanBuild, true);
    }
}
