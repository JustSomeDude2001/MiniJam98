using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorTracker : MonoBehaviour
{
    public static Vector3Int cursorPos;
    public static Grid selfGrid;
    public Camera mainCam;

    private void Start() {
        selfGrid = GetComponent<Grid>();
    }

    private void Update() {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        cursorPos = (selfGrid.WorldToCell(mousePos));
    }
}
