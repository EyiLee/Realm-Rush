using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 5;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    void OnParticleCollision (GameObject other) {
        ProcessHit();

        if (hitPoints <= 0) {
            KillEnemy();
        }
    }

    void ProcessHit () {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }

    void KillEnemy () {
        Instantiate(deathParticlePrefab, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }
}
