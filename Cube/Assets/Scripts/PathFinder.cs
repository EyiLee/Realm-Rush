using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    public List<Waypoint> path = new List<Waypoint>();

    [SerializeField] private Waypoint startWaypoint, endWaypoint;

    public List<Waypoint> GetPath () {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }

    private Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void CreatePath () {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint) {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startWaypoint);
        path.Reverse();
    }

    private void LoadBlocks () {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints) {
            Vector2Int gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos)) {
                Debug.LogWarning("Overlapping block " + waypoint);
            } else {
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.gray);
            }
        }
    }

    private void ColorStartAndEnd () {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void BreadthFirstSearch () {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning) {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound () {
        if (searchCenter == endWaypoint) {
            isRunning = false;
        }
    }

    private void ExploreNeighbors () {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions) {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighborCoordinates)) {
                QueNewNeighbor(neighborCoordinates);
            }
        }
    }

    private void QueNewNeighbor (Vector2Int neighborCoordinates) {
        Waypoint neighbor = grid[neighborCoordinates];
        if (neighbor.isExplored || queue.Contains(neighbor)) {
            // do nothing
        } else {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }
}
