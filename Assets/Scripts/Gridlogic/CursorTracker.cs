using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Attach this on cursor to track its grid position in a
/// static vector
/// </summary>
public class CursorTracker : MonoBehaviour
{
    /// <summary>
    /// Position of the cursor on the grid
    /// </summary>
    [HideInInspector]
    public static Vector3Int cursorPos;
    public static Grid selfGrid;
    public Camera mainCam;

    private void Start() {
        selfGrid = GetComponent<Grid>();
    }

    private void Update() {
        Vector2 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        cursorPos = (selfGrid.WorldToCell(mousePos));
        if (cursorPos.x < 0) {
            cursorPos.x = 0;
        }
        if (cursorPos.y < 0) {
            cursorPos.y = 0;
        }
        if (cursorPos.x >= GridMatrix.width) {
            cursorPos.x = GridMatrix.width - 1;
        }
        if (cursorPos.y >= GridMatrix.height) {
            cursorPos.y = GridMatrix.height - 1;
        }
    }
}
