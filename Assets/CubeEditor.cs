using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();  
    }
    void Update()
    {
        SnaoToGrid();
        UpdatetheLabel();
    }

    private void SnaoToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3
            (
            waypoint.GetGridPos().x*gridSize,
            0f, 
            waypoint.GetGridPos().y* gridSize
            );
    }

 
    private void UpdatetheLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh = GetComponentInChildren<TextMesh>();
        var labelText = 
            waypoint.GetGridPos().x  + ","
            + waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        name = "Cube (" + labelText + ")";
    }
}
