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

    [SerializeField] AudioClip enemyTakeDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    AudioSource audioSource;


    private void Start()
    {

        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(enemyTakeDamageSFX);
    }

    private void EnemyDeath()
    {
        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity, fxParrent);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, .5f);
        Destroy(gameObject);

    }

    public void SelfDestruct()
    {

        Instantiate(enemyDeathEffect, transform.position, Quaternion.identity, fxParrent);
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, .5f);
        Destroy(gameObject);
        if (_base)
        _base.DecreaseHP();
    }
}
