using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] GameObject bullets; 
    [SerializeField] Transform objectToPan;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] AudioClip shotSound;
    Transform targetEnemy;
    [HideInInspector]
    public Waypoint baseWaypoint;



    private void Start()
    {
        Shoot(false);
    }

    void Update ()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
	}
    //Моя реализация
    /*private void SetTargetEnemy()
    {
        Enemy[] sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0) { return; }
        targetEnemy = sceneEnemies[0].transform;
        foreach (Enemy enemy in sceneEnemies)
        {
            float distanceToCurrentEnemy = Vector3.Distance(enemy.transform.position, transform.position);
            float distanceToClosest = Vector3.Distance(targetEnemy.position, transform.position);
            if (distanceToCurrentEnemy < distanceToClosest)
            {
                targetEnemy = enemy.transform;
            }
        }
    }*/

    //Реализация из курса
    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<Enemy>();
        if (sceneEnemies.Length == 0) return;
        Transform closestEnemy = sceneEnemies[0].transform;
        foreach (Enemy enemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform clstEnemy, Transform currentEnemy)
    {
        float distanceToClosestEnemy = Vector3.Distance(clstEnemy.position, transform.position);
        float distanceToCurrentEnemy = Vector3.Distance(currentEnemy.position, transform.position);
        return (distanceToClosestEnemy < distanceToCurrentEnemy) ? clstEnemy : currentEnemy;
    }

    private void FireAtEnemy()
    {
        float distance = Vector3.Distance(targetEnemy.position, transform.position);

        if (shootDistance >= distance)
        {
            LookAtEnemy(objectToPan, targetEnemy);
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void LookAtEnemy(Transform cannon, Transform enemy)
    {
        cannon.LookAt(enemy, Vector3.up);
    }

    void Shoot(bool isActive)
    {

        bullets.SetActive(isActive);

    }
}
