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
	}

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);
        while (queue.Count > 0 && isRunning)
        {
            WayPoint searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching from: " + searchCenter);   // todo remove log
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }
        // todo work out path!
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

    private void ExploreNeighbours(WayPoint searchingFrom)
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchingFrom.GetGridPos() + direction;
            try
            {
                QueueNewNeighours(neighbourCoordinates);
            }
            catch
            {
                // Do nothing
            }
        }
    }

    private void QueueNewNeighours(Vector2Int neighbourCoordinates)
    {
        WayPoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored)
        {
            // Do nothing
        }
        else
        {
            neighbour.SetTopColor(Color.blue);   // todo move later
            queue.Enqueue(neighbour);
            print("Queueing " + neighbour);
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
