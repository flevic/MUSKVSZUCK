using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations; 
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
    public int maxHealth = 100; // Maximum health of the AI character
    public int currentHealth;  // Current health of the AI character
    
    public Slider healthSlider;

    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHealthBar();
        anim = this.GetComponent<Animator>();
     
        
 
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
           Destroy(gameObject);
        }
    }

    // Update the health bar UI
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)currentHealth / maxHealth;
        }
    }
    private void Update()
    {
       
        isGrounded = Physics2D.OverlapCircle(transform.position, 5f, groundLayer);

      
            if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
             
            // Check if the AI is within stopping distance
            if (distanceToPlayer > stoppingDistance)
            {
                

                float horizontal = Mathf.Sign(player.position.x - transform.position.x);
                Vector2 movement = new Vector2(horizontal, 0);

                rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
                if (horizontal > 0)
                {
                   
                    // Player is moving to the right
                    transform.rotation = Quaternion.Euler(0, 180, 0); // No rotation
                   
                }
                else if (horizontal < 0)
                {
                    
                    // Player is moving to the left
                    transform.rotation = Quaternion.Euler(0, 0, 0); // Flip on the Y-axis
                   
                }
               
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
                    anim.Play("JumpM"); 
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