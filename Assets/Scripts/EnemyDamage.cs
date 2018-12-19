using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 100;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);

    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.Play(); 
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
