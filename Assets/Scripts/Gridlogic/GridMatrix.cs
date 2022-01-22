using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMatrix : MonoBehaviour
{
    private static List<List<GameObject> > matrix;
    
    public static Grid selfGrid;
    public static int height = 12;
    public static int width = 20;

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

    public static GameObject GetObject(Vector3Int position) {
        return matrix[position.y][position.x];
    }

    public static void Destroy(Vector3Int position) {
        if (matrix[position.y][position.x] != null) {
            Destroy(matrix[position.y][position.x]);
        }
        matrix[position.y][position.x] = null;
    }

    public static void Build(Vector3Int position, GameObject newObject) {
        Destroy(position);
        matrix[position.y][position.x] = newObject;
    }

    /// <summary>
    /// Will need for upgrades (maybe)
    /// </summary>
    /// <param name="position"></param>
    public static void Interact(Vector3Int position) {

    }
}
