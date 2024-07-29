using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class ExperianceManager : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] int experiance, expToAdvance;

    [SerializeField] bool levelBoost = false;

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        expToAdvance = 100;
        level = 1;
        if (levelBoost == true)
        {
            level = 10;
        }
    }

    void LevelUp()
    {
        level += 1;
        expToAdvance += 100 + (level * 25);

        playerManager.maxHealth += 2;
        playerManager.HealDamage(100);
        
        playerStats.attack += 1;
        playerStats.defense += 1;
        playerStats.agility += 1;
        playerStats.intelligence += 1;

        playerStats.UpdateEquipment();
    }

    void LevelDown()
    {
        level -= 1;
        expToAdvance += 100 + (level * 25);
        experiance = 100 + (level * 25);

        playerManager.maxHealth -= 1;

        playerStats.attack -= 1;
        playerStats.defense -= 1;
        playerStats.agility -= 1;
        playerStats.intelligence -= 1;

        playerStats.UpdateEquipment();
    }

    public void AddExp(int newExp)
    {
        experiance += newExp;
        if (experiance <= 0)
        {
            //experiance = 0;
            LevelDown();
        }
        if (experiance >= expToAdvance)
        {
            LevelUp();
        }
    }

    public void RemoveExp(int newExp)
    {
        experiance -= newExp;
        if (experiance <= 0)
        {
            //experiance = 0;
            LevelDown();
        }
    }
}
