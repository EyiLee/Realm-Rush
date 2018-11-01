using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] int spawnsNum = 200;
    [SerializeField] float spawnsPeriod = 2f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySFX;

    int score = 0;
    AudioSource audioSource;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
    }

    void Start () {
        StartCoroutine(RepeatlySpwanEnemies());
        spawnedEnemies.text = score.ToString();
    }

    IEnumerator RepeatlySpwanEnemies () {
        for (int i = 0; i < spawnsNum; i++) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            audioSource.PlayOneShot(spawnedEnemySFX);
            AddScore();
            yield return new WaitForSeconds(spawnsPeriod);
        }
    }

    void AddScore () {
        score++;
        spawnedEnemies.text = score.ToString();
    }
}
