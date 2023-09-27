using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public bool Trigger = false;

    // This method gets called when something enters the trigger area of the collectible.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding GameObject has a "Player" tag.
        if (other.CompareTag("AICharacter"))
        {
            Trigger = true;
        }
    }
}
