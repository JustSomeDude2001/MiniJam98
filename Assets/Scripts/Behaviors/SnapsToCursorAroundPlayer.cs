using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes item snap to grid, while staying within
/// a specific radius around player. 
/// </summary>
public class SnapsToCursorAroundPlayer : MonoBehaviour
{
    public float radius = 4;
    void Update()
    {
        Vector3 offset = CursorTracker.selfGrid.CellToWorld(CursorTracker.cursorPos) - Player.playerPos;
        if (offset.magnitude > radius) {
            offset *= radius / offset.magnitude;
        }

        Vector3Int cellPos = CursorTracker.selfGrid.WorldToCell(Player.playerPos + offset);

        Vector3 newPos = CursorTracker.selfGrid.CellToWorld(cellPos) + 
                         CursorTracker.selfGrid.cellSize / 2f;
        
        transform.position = newPos;
    }
}
