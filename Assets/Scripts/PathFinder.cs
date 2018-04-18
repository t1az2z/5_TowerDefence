using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    [SerializeField] private List<Waypoint> path = new List<Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        //todo uncomment when fixed SetTopColor() method from Waypoint class
        //ChangeStartAndEndTopColor();
        BreadthFirstSearch();
        CreatePath();
        return path;
    }


    private void CreatePath()
    {
        path.Add(endWaypoint);

        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
            
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();

            ExploreNeighbours();

        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            print("searching from end node " + searchCenter); // todo remove
            isRunning = false;
        }
    }

private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoords = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoords))
            {

                QueueNewNeighbour(neighbourCoords);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoords)
    {
        Waypoint neighbour = grid[neighbourCoords];
        if (!neighbour.isExplored && !queue.Contains(neighbour))
        {
            neighbour.exploredFrom = searchCenter;
            queue.Enqueue(neighbour);
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
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

}
