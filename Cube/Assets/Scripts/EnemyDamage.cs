using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    private int hitPoints = 10;

    [SerializeField] private Collider collisionMesh;

    private void OnParticleCollision (GameObject other) {
        ProcessHit();
        if (hitPoints <= 0) {
            KillEnemy();
        }
    }

    private void ProcessHit () {
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy () {
        Destroy(gameObject);
    }
}
