using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float mouseSensitivity = 100;

    public Transform playerBody;

    private float xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;        
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; //follows the rigth rotation when moving
        xRotation = Mathf.Clamp(xRotation, -90, 90); //prevents player flipping around the axis when looking

        transform.localRotation = UnityEngine.Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(UnityEngine.Vector3.up * mouseX);
    }
}
