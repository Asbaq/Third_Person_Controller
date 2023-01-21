using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Initializing the GameObject
    public CharacterController controller;
    public float speed = 6f;
    public float mouseSensitivity = 10f;
    
    void Update()
    {
        // For Player Movement in X and Z Axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
}
