using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public LayerMask groundLayer; // Define the ground layer
    private bool isGrounded;
    private Rigidbody2D rigidbody2d;
    public float punchDelay = 1.0f; // Time between punches
    public int punchDamage = 10;    // Damage per punch
    private Transform triggerZone;
    private float nextPunchTime = 0f;
    public bool inarea = false;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        GameObject triggerZone = GameObject.Find("TriggerZonePlayer");
        CheckerPlayer targetScript = triggerZone.GetComponent<CheckerPlayer>();
        if (targetScript != null)
        {
            
             inarea = targetScript.Trigger;
            // Use the value as needed.
        }

        if (inarea == true)
        {
            Debug.Log("ITTRUE");
        }
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontal, 0);

        rigidbody2d.velocity = new Vector2(movement.x * moveSpeed, rigidbody2d.velocity.y);

        // Check if the player is grounded using OverlapCircle
        isGrounded = Physics2D.OverlapCircle(transform.position, 2.5f, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward force for jumping
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextPunchTime && inarea == true)
        {
            // Check if the AI character is within the trigger zone.


            Debug.Log("UhOH");

            // Trigger the punch animation or attack here if you have one.
            GameObject aiCharacter = GameObject.Find("AI");
            AIHealth aiHealth = aiCharacter.GetComponent<AIHealth>();
                        if (aiHealth != null)
                        {
                Debug.Log("KYS");
                aiHealth.TakeDamage(punchDamage);
                        }

                        // Set the time for the next punch.
                        nextPunchTime = Time.time + punchDelay;
                    
                    // Apply damage to the AI character.

                
            }
        

        

        if (horizontal > 0)
        {
            // Player is moving to the right
            transform.rotation = Quaternion.Euler(0, 0, 0); // No rotation
        }
        else if (horizontal < 0)
        {
            // Player is moving to the left
            transform.rotation = Quaternion.Euler(0, 180, 0); // Flip on the Y-axis
        }
    }

}
