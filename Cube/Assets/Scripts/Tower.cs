using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] float attackRange;
    [SerializeField] ParticleSystem projectileParticle;

    private void Update () {
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        } else {
            Shoot(false);
        }
    }

    private void FireAtEnemy () {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange) {
            Shoot(true);
        } else {
            Shoot(false);
        }
    }

    private void Shoot (bool isActive) {
        ParticleSystem.EmissionModule emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
