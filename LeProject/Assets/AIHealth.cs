using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class AIHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxHealth = 100; // Maximum health of the AI character
    public int aiHealth;  // Current health of the AI character

    public Slider healthSlider;

    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiHealth = maxHealth;
        UpdateHealthBar();
        anim = this.GetComponent<Animator>();
        



    }
    public void TakeDamage(int damageAmount)
    {
        Debug.Log("KYS2");
        aiHealth -= damageAmount;
        aiHealth = Mathf.Clamp(aiHealth, 0, maxHealth);

        UpdateHealthBar();

        if (aiHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update the health bar UI
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = (float)aiHealth / maxHealth;
        }
    }
    private void Update()
    {




    }



}