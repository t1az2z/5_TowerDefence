using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit;
    [SerializeField] GameObject towerParrent;
    Queue<Tower> towerQueue = new Queue<Tower>();
    
    
    public void AddTower(Waypoint baseWaypoint)
    {
        int numberOfTowers = towerQueue.Count;
        if (numberOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }

    private void InstantiateNewTower(Waypoint _baseWaypoint)
    {
        Tower tower = Instantiate(towerPrefab, _baseWaypoint.transform.position, Quaternion.identity, towerParrent.transform);
        tower.baseWaypoint = _baseWaypoint;
        _baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint _baseWaypoint)
    {
        Tower tower = towerQueue.Dequeue();
        tower.baseWaypoint.isPlaceable = true;
        tower.transform.position = _baseWaypoint.transform.position;
        tower.baseWaypoint = _baseWaypoint;
        _baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(tower);
    }


}
