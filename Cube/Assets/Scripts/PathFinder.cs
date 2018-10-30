using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    readonly Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();
    bool isRunning = true;
    Waypoint searchPoint;

    public List<Waypoint> GetPath () {
        if (path.Count == 0) {
            LoadWaypoints();
            BreadthFirstSearch();
            CreatePath();
        }
        return path;
    }

    void LoadWaypoints () {
        Waypoint[] waypoints = GetComponentsInChildren<Waypoint>();

        foreach (Waypoint waypoint in waypoints) {
            Vector2Int gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Overlapping block " + waypoint);
            } else {
                grid.Add(gridPos, waypoint);
            }
        }
    }

    void BreadthFirstSearch () {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning) {
            searchPoint = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchPoint.isExplored = true;
        }
    }

    void HaltIfEndFound () {
        if (searchPoint == endWaypoint) {
            isRunning = false;
        }
    }

    void ExploreNeighbors () {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions) {
            Vector2Int neighborCoordinates = searchPoint.GetGridPos() + direction;
            if (grid.ContainsKey(neighborCoordinates)) {
                QueNewNeighbor(neighborCoordinates);
            }
        }
    }

    void QueNewNeighbor (Vector2Int neighborCoordinates) {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor)) {
            // do nothing
        } else {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchPoint;
        }
    }

    void CreatePath () {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint) {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }
}
