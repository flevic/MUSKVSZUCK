using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerPlayer : MonoBehaviour
{
    public bool Trigger = false;

    // This method gets called when something enters the trigger area of the collectible.
    
    // Check if the colliding GameObject has a "AICharacter" tag.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding GameObject has a "Player" tag.
        if (other.CompareTag("AICharacter"))
        {
            Trigger = true;
        }
    }

    // This method gets called when something exits the trigger area.
    private void OnTriggerExit2D(Collider2D other)
{
    // Check if the colliding GameObject has a "AICharacter" tag.
    if (other.CompareTag("AICharacter"))
    {
        Trigger = false;
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
