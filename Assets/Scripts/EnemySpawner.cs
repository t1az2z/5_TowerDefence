using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int numberOfEnemiesToSpawn = 20;

    private void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

}
