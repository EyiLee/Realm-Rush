using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] int spawnsNumber = 10;
    [SerializeField] GameObject enemyPrefab;

    private void Start () {
        StartCoroutine(RepeatlySpwanEnemies());
    }

    private IEnumerator RepeatlySpwanEnemies () {
        for (int i = 0; i < spawnsNumber; i++) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform.parent);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
