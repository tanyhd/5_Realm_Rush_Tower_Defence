﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    // Parameters of each tower
    [SerializeField] List<Transform> objectToPan = new List<Transform>();
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    // State of each tower
    Transform targetEnemy;

    // Update is called once per frame
    void Update ()
    {
        SetTargetEnemy();

        if (targetEnemy)
        {
            foreach (Transform gameObjects in objectToPan)
            {
                gameObjects.LookAt(targetEnemy);
            }
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var disToA = Vector3.Distance(transform.position, transformA.position);
        var disToB = Vector3.Distance(transform.position, transformB.position);

        if (disToA > disToB)
        {
            return transformB;
        }
        return transformA;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
