using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody rb;
    private Transform camTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform; // Get the main camera's transform
    }

    private void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction relative to camera's rotation
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;

        // Remove any influence of the camera's y position
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate movement direction
        Vector3 moveDirection = (forward * verticalInput + right * horizontalInput).normalized;

        // Apply movement
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        // Jump input
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        // Implement your own ground check logic here (e.g., raycasting)
        // Return true if the player is grounded, false otherwise
        // For simplicity, I'll assume the player is always grounded
        return true;
    }
}
