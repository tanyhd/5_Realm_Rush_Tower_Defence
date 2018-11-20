using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<WayPoint> path;
	// Use this for initialization
	void Start () {
        StartCoroutine(FollowPath());
	}

    IEnumerator FollowPath()
    {
        print("Starting patrol...");
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            print("Visiting block: " + wayPoint.name);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }

    // Update is called once per frame
    void Update () {

	}
}
