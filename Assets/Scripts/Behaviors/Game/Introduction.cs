using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Introduction : MonoBehaviour
{
    public List<string> statements;
    public LoadsScene sceneLoader;
    public TMPro.TMP_Text text;

    public float cooldown;
    
    private int _currentStatement = 0;
    private float _lastTextChange = 0;

    private void Start()
    {
        text.text = statements[0];
    }

    public void Progress()
    {
        if (Time.time - _lastTextChange < cooldown)
        {
            return;
        }

        _lastTextChange = Time.time;
        _currentStatement++;
        if (statements.Count <= _currentStatement)
        {
            sceneLoader.Load();
            return;
        }

        text.text = statements[_currentStatement];
    }
    
}