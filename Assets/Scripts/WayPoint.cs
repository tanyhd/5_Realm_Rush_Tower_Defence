using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

    [SerializeField] Color exploredColor = Color.blue;

    // public ok here as this is a data class
    public bool isExplored = false;
    public WayPoint exploreFrom;
    public bool isPlaceable = true;

    const int gridSize = 10;
    Vector2Int gridPos;

    private void Update()
    {

    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                print(gameObject.name + " tower placement");
            }
            else
            {
                print("Cannot be place here");
            }
        }
    }
}
