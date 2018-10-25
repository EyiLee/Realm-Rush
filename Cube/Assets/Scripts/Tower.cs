using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;

    private void Update () {
        objectToPan.LookAt(targetEnemy);
    }
}
