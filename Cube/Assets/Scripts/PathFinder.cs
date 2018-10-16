using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    private void Start () {
        LoadBlocks();
    }

    private void LoadBlocks () {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Overlapping block " + waypoint);
            } else {
                grid.Add(gridPos, waypoint);
            }
        }
    }
}
