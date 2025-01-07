using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingProjectile : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject normalProjectilePrefab;
    public GameObject paralyzingProjectilePrefab;
    public float launchVelocity = 10f;
    public float velocityChangeAmount = 2f; // Change in velocity per key press

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Left Mouse Click
        {
            Cursor.visible = false; // Hide cursor when mouse is clicked

            GameObject projectilePrefab = Random.Range(0f, 1f) < 0.5f ? normalProjectilePrefab : paralyzingProjectilePrefab;

            var projectile = Instantiate(projectilePrefab, launchPoint.position, launchPoint.rotation);
            projectile.GetComponent<Rigidbody>().linearVelocity = launchPoint.up * launchVelocity;
        }

        // Increase velocity when 'E' is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            launchVelocity += velocityChangeAmount;
            Cursor.visible = false; // Hide the cursor when 'E' is pressed
        }

        // Decrease velocity when 'Q' is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            launchVelocity -= velocityChangeAmount;
            if (launchVelocity < 0f) // Ensure velocity doesn't go below 0
            {
                launchVelocity = 0f;
            }
            Cursor.visible = false; // Hide the cursor when 'Q' is pressed
        }

        if (Input.GetKeyDown(KeyCode.Tab)) // Example key to show the cursor again
        {
            Cursor.visible = true;
        }
    }
}