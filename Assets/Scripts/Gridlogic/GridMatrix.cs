using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General tracker of items on the playing field.
/// Attach this to grud for convenience.
/// </summary>
public class GridMatrix : MonoBehaviour
{
    private static List<List<GameObject> > matrix;
    
    public static Grid selfGrid;
    public static int height = 19;
    public static int width = 16;

    private void Start() {
        selfGrid = GetComponent<Grid>();
        matrix = new List<List<GameObject> >();
        for (int i = 0; i < height; i++) {
            matrix.Add(new List<GameObject>());
            for (int j = 0; j < width; j++) {
                matrix[i].Add(null);
            }
        }
    }

    /// <summary>
    /// Get random grid position that is not occupied.
    /// </summary>
    /// <returns>A cell position in grid</returns>
    public static Vector3Int GetRandomFreePos() {
        List<Vector3Int> validPositions = new List<Vector3Int>();
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                if (GetObject(new Vector3Int(j, i, 0)) == null) {
                    validPositions.Add(new Vector3Int(j, i, 0));
                }
            }
        }
        if (validPositions.Count == 0) {
            return Vector3Int.forward;
        }
        return validPositions[Random.Range(0, validPositions.Count)];
    }


    public static Vector3 GetRandomEdgePos() {
        int i = 0;
        int j = 0;
        if (Random.Range(0, 2) == 0) {
            if (Random.Range(0, 2) == 0) {
                i = height;
            } else {
                i = 0;
            }
            j = Random.Range(0, width + 1);
        } else {
            i = Random.Range(0, height + 1);
            if (Random.Range(0, 2) == 0) {
                j = width;
            } else {
                j = 0;
            }
        }

        Vector3 newPos = selfGrid.CellToWorld(new Vector3Int(j, i, 0));
        //Debug.Log(newPos);
        return newPos;
    }

    public static GameObject GetObject(Vector3Int position) {
        if (position.y < 0 || position.x < 0) {
            return null;
        }
        if (position.y >= height || position.x >= width) {
            return null;
        }
        return matrix[position.y][position.x];
    }

    public static void Destroy(Vector3Int position) {
        matrix[position.y][position.x] = null;
    }

    public static void Build(Vector3Int position, GameObject newObject) {
        matrix[position.y][position.x] = newObject;
    }

    private void OnDestroy() {
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                if (matrix[i][j] != null) {
                    Destroy(matrix[i][j]);
                }
            }
        }
    }
}
