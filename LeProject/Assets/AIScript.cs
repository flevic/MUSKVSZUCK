using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AIScript : MonoBehaviour
{
    public  Animator anim;
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
        GameObject triggerZone = GameObject.Find("TriggerZoneAI");
        CheckerAI targetScript = triggerZone.GetComponent<CheckerAI>();
        if (targetScript != null)
        {

            inarea = targetScript.Trigger;
            // Use the value as needed.
        }

        float horizontal = Input.GetAxis("Horizontal2");

        Vector2 movement = new Vector2(horizontal, 0);

        rigidbody2d.velocity = new Vector2(movement.x * moveSpeed, rigidbody2d.velocity.y);
        // Check if the player is grounded using OverlapCircle
        isGrounded = Physics2D.OverlapCircle(transform.position, 2.5f, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump2"))
        {
            // Apply an upward force for jumping
             
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            

        }
     
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Ismoving", true);
        }
        else
        {
            anim.SetBool("Ismoving", false); 
        }
     




        if (Input.GetButtonDown("Fire2") && Time.time >= nextPunchTime && inarea == true)
        {
            // Check if the AI character is within the trigger zone.


            // Trigger the punch animation or attack here if you have one.
            GameObject playerCharacter = GameObject.Find("Player");
            PlayerHealth aiHealth = playerCharacter.GetComponent<PlayerHealth>();
            if (aiHealth != null)
            {
                Debug.Log("KYS2");
                aiHealth.TakeDamage(punchDamage);
            }

            // Set the time for the next punch.
            nextPunchTime = Time.time + punchDelay;

            // Apply damage to the AI character.

            
        }




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

}
