using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] int spawnsNumber = 10;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject spawnPoint;

    Transform parent;
    Vector3 spawnPosition;

    private void Awake () {
        parent = gameObject.GetComponentInParent<Transform>();
        spawnPosition = spawnPoint.transform.position;
    }

    private void Start () {
        StartCoroutine(RepeatlySpwanEnemies());
    }

    private IEnumerator RepeatlySpwanEnemies () {
        for (int i = 0; i < spawnsNumber; i++) {
            Instantiate(enemy, spawnPosition, Quaternion.identity, parent);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
