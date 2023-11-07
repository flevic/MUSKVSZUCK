using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPlayer : MonoBehaviour
{
    public bool Trigger = false;

    // This method gets called when something enters the trigger area of the collectible.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("INAREA2");
        // Check if the colliding GameObject has a "Player" tag.
        if (other.CompareTag("AICharacter"))
        {
            Debug.Log("INAREA3");
            Trigger = true;
        }
    }
    private void Update()
    { 
    
        if (Trigger == true)
        {
            Debug.Log("Trigger");
        }
    }
}
