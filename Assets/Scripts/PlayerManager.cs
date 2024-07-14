using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Slider healthSlider;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthSlider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HealDamage(int amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthSlider.value = health;
    }
}
