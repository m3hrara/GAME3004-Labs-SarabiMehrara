using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Player Camera Properties")]
    public float controlSensitivity = 10.0f;
    public Transform playerBody;
    public Joystick rightJoystick;

    private float xRotation = 0.0f;

    void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        float horizontal = rightJoystick.Horizontal * controlSensitivity;
        float vertical = rightJoystick.Vertical * controlSensitivity;

        xRotation -= vertical;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * horizontal);
    }
}