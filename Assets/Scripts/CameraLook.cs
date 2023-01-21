using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    // Initializing the GameObject
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Update()
    {
        // For Mouse Rotation on X axis
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
