using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] private int hitPoints = 10;
    [SerializeField] private Collider collisionMesh;
    [SerializeField] private ParticleSystem hitParticlePrefab;
    [SerializeField] private ParticleSystem deathParticlePrefab;

    private void OnParticleCollision (GameObject other) {
        ProcessHit();
        if (hitPoints <= 0) {
            KillEnemy();
        }
    }

    private void ProcessHit () {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    private void KillEnemy () {
        Instantiate(deathParticlePrefab, transform.position, Quaternion.identity, transform);
        Destroy(gameObject);
    }
}
