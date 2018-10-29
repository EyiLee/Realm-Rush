using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MapCube))]
public class MapCubeEditor : MonoBehaviour {

    MapCube mapCube;

    void Awake () {
        mapCube = GetComponent<MapCube>();
    }

    void Update () {
        SnapToGrid();
        UpdateName();
    }

    void SnapToGrid () {
        transform.position = new Vector3(
            mapCube.GetGridPos().x * mapCube.GetGridSize(),
            0f,
            mapCube.GetGridPos().y * mapCube.GetGridSize()
        );
    }

    void UpdateName () {
        gameObject.name = mapCube.GetGridPos().x + "," + mapCube.GetGridPos().y;
    }
}
