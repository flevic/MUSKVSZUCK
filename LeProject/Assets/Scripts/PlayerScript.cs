using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayer; // Define the ground layer
    private bool isGrounded;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0);

        rigidbody2d.velocity = new Vector2(movement.x * moveSpeed, rigidbody2d.velocity.y);

        // Check if the player is grounded using OverlapCircle
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward force for jumping
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

      
    }

}
