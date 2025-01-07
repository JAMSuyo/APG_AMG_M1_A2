using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchCannon : MonoBehaviour
{
    public Transform cannonSpawn;
    public GameObject cannonball;
    public float acceleration = 10f;
    public float initialVelocity = 7f;
    public float launchTime = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    private void Launch()
    {
        GameObject newBall = Instantiate(cannonball, cannonSpawn.position, cannonSpawn.rotation);

        Rigidbody rb = newBall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float displacement = 0.5f * acceleration * launchTime * initialVelocity * launchTime;

            Vector3 launchDirection = cannonSpawn.up * displacement;

            rb.linearVelocity = launchDirection;

            rb.AddForce(launchDirection, ForceMode.Impulse);
        }
    }
}