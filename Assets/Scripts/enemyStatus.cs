using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool isStunned = false;
    private float stunEndTime;

    public float normalSpeed = 5f;
    public float stunnedSpeed = 2f;

    void Update()
    {
        if (!isStunned)
        {
            Move(normalSpeed);
        }
        else
        {
            Move(stunnedSpeed);
            if (Time.time >= stunEndTime)
            {
                EndStun();
            }
        }
    }

    void Move(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Stun(float duration)
    {
        isStunned = true;
        stunEndTime = Time.time + duration;
    }

    void EndStun()
    {
        isStunned = false;
    }
}
