using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded = true;
    [SerializeField]
    private float speed = 12f;
    [SerializeField]
    private float Jumpspeed = 8f;
    private float x;
    private float z;
    public float mouseSensitivity = 100f;
    Camera ViewCamera;
   // public Transform playerBody;
    float xRotation = 0f;
    void Awake()
    {

        rb = GetComponent<Rigidbody>();
         ViewCamera = Camera.main;
    }

    void Update()
    {
        Inputs();
        
    }
    void FixedUpdate()
    {
        Move();
        Jump();
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
    
    private void Inputs()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(x,0,z) * speed);
    }
    
   private void Jump()
   {
     if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(Vector3.up * Jumpspeed, ForceMode.Impulse);
            isGrounded = false;
        }
       if(rb.position.y < 0.5f)
      {
        isGrounded = true;
      }
   }

    void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }
}
