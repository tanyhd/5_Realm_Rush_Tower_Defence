using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Block> path;
	// Use this for initialization
	void Start () {
        PrintAllWayPoints();
	}

    private void PrintAllWayPoints()
    {
        foreach (Block wayPoint in path)
        {
            print(wayPoint.name);
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
