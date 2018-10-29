using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour {

    const int gridSize = 11;

    public int GetGridSize () {
        return gridSize;
    }

    public Vector2Int GetGridPos () {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }
}
