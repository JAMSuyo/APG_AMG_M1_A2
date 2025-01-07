using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public float rotSpeed = 50f;
    public float mouseSensitivity = 1f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float horizontalMouse = Input.GetAxis("Mouse X");

        float combiInput = horizontal + (horizontalMouse * mouseSensitivity);

        RotateCannon(combiInput);
    }

    void RotateCannon(float input)
    {
        transform.Rotate(Vector3.up, input * rotSpeed * Time.deltaTime);
    }
}
