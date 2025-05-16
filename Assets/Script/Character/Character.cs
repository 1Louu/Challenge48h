using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1f;
    public int life = 3;
    public Camera PlayerCamera;
    public void Move(Vector3 velocity)
    {
        rb.MovePosition(rb.position + velocity * speed);
    }

    public void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void LooseLife()
    {
        life--;
        if (life <= 0)
        {
            
        }
    }
}
