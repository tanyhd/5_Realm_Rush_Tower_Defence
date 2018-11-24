using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    [SerializeField] WayPoint startWaypoint;
    [SerializeField] WayPoint endWaypoint;
    Queue<WayPoint> queue = new Queue<WayPoint>();
    [SerializeField] bool isRunning = true; // todo make private

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left,
        Vector2Int.down
    };

	// Use this for initialization
	void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        // ExploreNeighbours();
	}

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0)
        {
            WayPoint searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter);   // todo remove log
            HaltIfEndFound(searchCenter);
        }

        print("Finish pathfinding?");
    }

    private void HaltIfEndFound(WayPoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Searching from end node, therefore stopping");   // todo remove log
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch
            {
                // Do nothing
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
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

    }

    // Update is called once per frame
    void Update () {
		
	}
}
