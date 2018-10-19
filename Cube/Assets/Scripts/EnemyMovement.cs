using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private List<Waypoint> path;

    private void Start () {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.GetPath();
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath () {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            print("Visiting: " + waypoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}
