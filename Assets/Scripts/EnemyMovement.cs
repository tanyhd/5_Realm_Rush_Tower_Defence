using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalDeathVFX;

    // Use this for initialization
    void Start () {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();

        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
	}

    IEnumerator FollowPath(List<WayPoint> path)
    {
        //print("Starting patrol...");
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }

        SelfDestruct();
    }

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalDeathVFX, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }
}
