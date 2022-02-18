using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes item snap to grid, while staying within
/// a specific radius around player. 
/// </summary>
public class SnapsToCursorAroundPlayer : MonoBehaviour
{
    public Stat radius;

    public Builds builder;
    public Upgrades upgrader;

    public void Toggle(bool value)
    {
        builder.isInRadius = value;
        upgrader.isInRadius = value;
    }

    void Update()
    {
        bool newState = !((transform.position - Player.playerPos).magnitude > radius.GetValue());

        /**if (Player.isOnPause) {
            return;
        }**/
        
        Vector3 offset = GridMatrix.selfGrid.CellToWorld(CursorTracker.cursorPos) - Player.playerPos;
        /**if (offset.magnitude > radius.GetValue()) {
            offset *= radius.GetValue() / offset.magnitude;
        }**/

        Vector3Int cellPos = GridMatrix.selfGrid.WorldToCell(Player.playerPos + offset);

        if (cellPos.y < 0)
        {
            newState = false;
            cellPos.y = 0;
        }

        if (cellPos.x < 0) {
            newState = false;
            cellPos.x = 0;
        }

        if (cellPos.y >= GridMatrix.height) {
            newState = false;
            cellPos.y = GridMatrix.height - 1;
        }

        if (cellPos.x >= GridMatrix.width) {
            newState = false;
            cellPos.x = GridMatrix.width - 1;
        }
        
        Debug.Log(newState);
        Toggle(newState);

        Vector3 newPos = GridMatrix.selfGrid.CellToWorld(cellPos) + 
                         GridMatrix.selfGrid.cellSize / 2f;
        
        transform.position = newPos;
    }
}
