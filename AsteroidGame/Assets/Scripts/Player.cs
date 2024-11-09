using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;  // Ensure this is assigned in the inspector

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
     
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    // 2D Collision Detection
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.gameObject.name);
        if (other.CompareTag("HealthPack"))
        {
            Heal(20); // Set the healing amount as needed
            Destroy(other.gameObject); // Optionally destroy the health pack
        }
    }

    void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Cap health at maxHealth
        healthBar.SetHealth(currentHealth);
    }
}
