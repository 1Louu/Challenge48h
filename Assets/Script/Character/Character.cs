using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    public Camera PlayerCamera;
    
    public float groundCheckDistance = 0.3f;  // Distance to check below the player
    public LayerMask groundMask; // Assign in Inspector to everything *except* the Player layer

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);
    }
    public void Move(Vector3 velocity)
    {
        rb.MovePosition(rb.position + velocity * speed);
    }

    public void Jump(float jumpForce)
    {
        if(IsGrounded())
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void LooseLife()
    {
        
    }
}
