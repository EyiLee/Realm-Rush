using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour {

    private float gridSize = 11f;

    TextMesh textMesh;

    private void Start () {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    private void Update () {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}
