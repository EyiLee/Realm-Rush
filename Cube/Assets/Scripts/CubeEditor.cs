using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    private Waypoint waypoint;
    private TextMesh textMesh;

    private void Awake () {
        waypoint = GetComponent<Waypoint>();
        textMesh = GetComponentInChildren<TextMesh>();
    }

    private void Update () {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid () {
        transform.position = new Vector3(
            waypoint.GetGridPos().x * waypoint.GetGridSize(),
            0f,
            waypoint.GetGridPos().y * waypoint.GetGridSize()
        );
    }

    private void UpdateLabel () {
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
