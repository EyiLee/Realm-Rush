using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectileParticle;

    Transform targetEnemy;
    public TowerBase towerBase;

    void Update () {
        SetTargetEnemy();
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
    }

    void SetTargetEnemy () {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies) {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    Transform GetClosest (Transform transformA, Transform transformB) {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB) {
            return transformA;
        } else {
            return transformB;
        }
    }

    void FireAtEnemy () {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange) {
            Shoot(true);
        } else {
            Shoot(false);
        }
    }

    void Shoot (bool isActive) {
        ParticleSystem.EmissionModule emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
