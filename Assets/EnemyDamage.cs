using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hit = 100;
    [SerializeField] GameObject deathFX;
    [SerializeField] Collider collisionMesh;

    private void Start()
    {
        
    }

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
