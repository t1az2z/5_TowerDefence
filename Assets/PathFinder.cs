using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint start, end;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start () {
        LoadBlocks();
        ChangeStartAndEndTopColor();
        ExploreNeighbours();
	}

    private void ExploreNeighbours()
    {
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoords = start.GetGridPos() + direction;
            try
            {
                grid[explorationCoords].SetTopColor(Color.blue);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.Log("Skiping overlaping block " + waypoint);
            }
            else
            {
                grid.Add(gridPos, waypoint);
            }
        }
    }
    private void ChangeStartAndEndTopColor()
    {
        start.SetTopColor(Color.green);
        end.SetTopColor(Color.red);
    }

}
