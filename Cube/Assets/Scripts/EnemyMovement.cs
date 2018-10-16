using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] private List<Waypoint> path;

    private void Start () {
        StartCoroutine(FollowPath());
        print("Hey I'm back at Start");
    }

    private void Update () {

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
