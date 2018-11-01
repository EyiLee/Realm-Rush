using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 3;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource audioSource;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
    }

    void OnParticleCollision (GameObject other) {
        ProcessHit();

        if (hitPoints <= 0) {
            KillEnemy();
        }
    }

    void ProcessHit () {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        audioSource.PlayOneShot(enemyHitSFX);
    }

    void KillEnemy () {
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Instantiate(deathParticlePrefab, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }
}
