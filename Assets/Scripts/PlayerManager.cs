using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public Slider healthSlider;
    public Slider CombatSlider;

    public GameObject GameOverCanvas;

    public event Action OnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        CombatSlider.maxValue = maxHealth;
        CombatSlider.value = health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthSlider.value = health;
        CombatSlider.value = health;

        if (health <= 0)
        {
            GameOverCanvas.SetActive(true);
            OnGameOver?.Invoke();
            //Destroy(gameObject);
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
        CombatSlider.value = health;
    }

    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;
        healthSlider.maxValue = maxHealth;
        CombatSlider.maxValue = health;
        HealDamage(amount);
    }
}
