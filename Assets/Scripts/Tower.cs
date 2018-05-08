using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
	

    void LookAtEnemy(Transform cannon, Transform enemy)
    {
        cannon.LookAt(enemy, Vector3.up);
    }
	void Update () {

        LookAtEnemy(objectToPan, targetEnemy);

	}
}
