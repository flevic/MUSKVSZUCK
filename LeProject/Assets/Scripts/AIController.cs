using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5.0f;
    public float stoppingDistance = 0.5f;
    public float jumpForce = 10.0f;
    private Rigidbody2D rb;
    private float timePlayerAbove = 0.0f;
    private bool playerAbove = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Check if the AI is within stopping distance
            if (distanceToPlayer > stoppingDistance)
            {
                float horizontal = Mathf.Sign(player.position.x - transform.position.x);
                Vector2 movement = new Vector2(horizontal, 0);

                rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            // Check if the AI can jump
            if (isGrounded && playerAbove)
            {
                timePlayerAbove += Time.deltaTime;

                if (timePlayerAbove >= 0.25f)
                {
                    
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                timePlayerAbove = 0.0f;
            }

            // Check if the player is above the AI
            if (player.position.y > transform.position.y)
            {
                playerAbove = true;
            }
            else
            {
                playerAbove = false;
                timePlayerAbove = 0.0f;
            }
        }
    }

    
    
}