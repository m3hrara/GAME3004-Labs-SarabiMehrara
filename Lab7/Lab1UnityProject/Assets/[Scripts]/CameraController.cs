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
        if (Application.platform != RuntimePlatform.Android)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal;
        float vertical;

        if (Application.platform != RuntimePlatform.Android)
        {
            horizontal = Input.GetAxis("Mouse X") * controlSensitivity;
            vertical = Input.GetAxis("Mouse Y") * controlSensitivity;
        }
        else
        {
            horizontal = rightJoystick.Horizontal * controlSensitivity;
            vertical = rightJoystick.Vertical * controlSensitivity;
        }

        xRotation -= vertical;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * horizontal);
    }
}