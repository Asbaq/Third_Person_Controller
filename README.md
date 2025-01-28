# 📝 Third_Person_Controller Documentation 🎮

## 📌 Game Overview  
![Third_Person_Controller](https://github.com/Asbaq/Third_Person_Controller/assets/62818241/95a1f2c7-dfbd-427c-9c5f-839e226cedbb)

**Third_Person_Controller** is a Unity-based **third-person character controller** that includes smooth movement, camera tracking, and jumping mechanics. This controller provides **basic player locomotion**, **camera rotation**, and **ground detection** for an engaging gameplay experience.

---

## 💪 Key Features

✅ **Smooth Third-Person Movement** using Character Controller.  
✅ **Camera Rotation** for dynamic player orientation.  
✅ **Jump Mechanic** with physics-based movement.  
✅ **Ground Detection System** to ensure proper jumping behavior.  
✅ **Customizable Movement Speed & Sensitivity** for better control.  

---

## 🎮 Game Mechanics

### 🏃 Player Movement (PlayerMovement.cs)
- Uses **Unity's CharacterController** for movement.
- Rotates the player based on **camera direction**.
- Implements **smooth turning and acceleration**.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    private float moveSpeed = 5f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 moveDirection;

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f ,verticalInput).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
```

### 🚀 Player Controls & Jumping (Player.cs)
- Uses **Rigidbody physics** for player movement.
- Allows **jumping when grounded**.
- Implements **mouse-controlled rotation** for looking around.

```csharp
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
```

---

## 🎤 Implementation Steps

1. **Create a Unity Project** and import the necessary assets.
2. **Add a player object** and attach a `CharacterController` component.
3. **Attach PlayerMovement.cs** to control player movement.
4. **Attach Player.cs** to enable jumping and camera rotation.
5. **Add a `Main Camera`** and assign it to the player for tracking.
6. **Ensure the ground is tagged as "Ground"** for proper jumping mechanics.
7. **Run the game and test** the movement and jump mechanics.

---

## 🚀 Features & Future Improvements

✅ **Smooth Third-Person Movement & Camera Tracking**  
✅ **Basic Jumping Mechanics**  
✅ **Customizable Speed & Rotation Sensitivity**  
✅ **Physics-Based Player Control**  

🔜 **Sprinting Mechanics**  
🔜 **Crouching & Dodging Movements**  
🔜 **Advanced Animation Integration**  

---

## 📌 Conclusion

**Third_Person_Controller** is a robust third-person character movement system for Unity. It includes **smooth player locomotion, camera tracking, jumping, and physics-based interactions**. Future updates may introduce **sprinting, crouching, and advanced animations** for a more immersive experience. 🚀
