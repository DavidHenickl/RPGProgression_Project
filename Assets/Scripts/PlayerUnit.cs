using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public Sprite unitSprite;

    public int damage;

    public int MaxHP;
    public int currentHP;

    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStats playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerManager = GameObject.Find("hero").GetComponent<PlayerManager>();

        damage = playerStats.attack;
        MaxHP = playerManager.maxHealth;
        currentHP = playerManager.health;
    }

    public void Refresh()
    {
        PlayerStats playerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        playerManager = GameObject.Find("hero").GetComponent<PlayerManager>();

        damage = playerStats.attack;
        unitLevel = GameObject.Find("StatManager").GetComponent<ExperianceManager>().level;
        MaxHP = playerManager.maxHealth;
        currentHP = playerManager.health;
    }

    public void UpdateHealth()
    {
        playerManager.health = currentHP;
        
    }

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        playerManager.TakeDamage(dmg);
        UpdateHealth();

        if (currentHP <= 0)
        {
            return true;
        }
        return false;
    }

}
