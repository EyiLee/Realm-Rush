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
        foreach (Waypoint waypoint in path) {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(2f);
        }
    }
}
