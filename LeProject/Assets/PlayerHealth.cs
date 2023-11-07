using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class PlayerHealth : MonoBehaviour
{
    public Rigidbody2D rb;
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




    }
}
