using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] Transform fxParrent;
    [SerializeField] int hp = 3;
    [SerializeField] GameObject enemyDamageEffeect;
    [SerializeField] GameObject enemyDeathEffect;
    Base _base;

    private void Start()
    {
        AddBoxCollider();
        _base = FindObjectOfType<Base>();
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

    public void SelfDestruct()
    {

        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity, fxParrent);
        Destroy(gameObject);
        if (_base)
        _base.DecreaseHP();
    }
}
