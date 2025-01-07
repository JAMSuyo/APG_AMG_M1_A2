using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalyzingProjectile : MonoBehaviour
{
    public float life = 20f;
    public float paralyzingDuration = 3f;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StunEnemy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }
    }

    void StunEnemy(GameObject enemy)
    {
        enemy.GetComponent<EnemyMovement>().Stun(paralyzingDuration);
    }
}