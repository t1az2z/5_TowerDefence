using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public int hp = 10;
    [SerializeField] int damagePerHit = 1;
    [SerializeField] float destroyDelay = 1f;

    [SerializeField] GameObject destructionFXPrefab;

    public void DecreaseHP()
    {
        hp -= damagePerHit;
        if (hp <= 0)
        {
            Destruction();
        }
    }

    public void Destruction()
    {
        Instantiate(destructionFXPrefab, transform.position, Quaternion.Euler(0, 0, 0), transform);
        Destroy(gameObject, 0.57f);
    }
}
