using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] Transform fxParrent;
    [SerializeField] int hp = 3;
    [SerializeField] GameObject enemyDamageEffeect;
    [SerializeField] GameObject enemyDeathEffect;

    private void Start()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    private void OnParticleCollision(GameObject other)
    {
        TakeHit();
        if (hp <= 0)
        {
            EnemyDeath();
        }

    }

    private void TakeHit()
    {
        hp--;
        Instantiate(enemyDamageEffeect, transform.position, Quaternion.identity, fxParrent);
    }

    private void EnemyDeath()
    {
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity, fxParrent);
        Destroy(gameObject);
    }
}
