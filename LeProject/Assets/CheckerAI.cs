using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerAI : MonoBehaviour
{
    public bool Trigger = false;

    // This method gets called when something enters the trigger area of the collectible.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding GameObject has a "Player" tag.
        if (other.CompareTag("PlayerCharacter"))
        {
            Trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the colliding GameObject has a "AICharacter" tag.
        if (other.CompareTag("PlayerCharacter"))
        {
            Trigger = false;
        }
    }
}
