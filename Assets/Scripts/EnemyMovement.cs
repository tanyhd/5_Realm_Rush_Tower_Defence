using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

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
            yield return new WaitForSeconds(1f);
        }
        //print("Ending patrol");
    }

    // Update is called once per frame
    void Update () {

	}
}
