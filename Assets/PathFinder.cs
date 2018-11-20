using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

	// Use this for initialization
	void Start () {
        LoadBlocks();
		
	}

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))  // to check if the blocks are overlapping each other
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);  // add to dictionary
            }
        }
        print("Loaded " + grid.Count + " blocks");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
