using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] int hit = 100;
    [SerializeField] GameObject deathFX;


    private void OnParticleCollision(GameObject other)
    {
        hit--;
        if (hit <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
