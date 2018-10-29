using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] int spawnsNum = 10;
    [SerializeField] float spawnsPeriod = 4f;
    [SerializeField] GameObject enemyPrefab;

    void Start () {
        StartCoroutine(RepeatlySpwanEnemies());
    }

    IEnumerator RepeatlySpwanEnemies () {
        for (int i = 0; i < spawnsNum; i++) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(spawnsPeriod);
        }
    }
}
