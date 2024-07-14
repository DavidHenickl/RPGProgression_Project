using System.Collections;
using System.Collections.Generic;
using UnityEditor.Playables;
using UnityEngine;

public class ExperianceManager : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] int experiance, expToAdvance;

    public int level;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        expToAdvance = 100;
        level = 1;
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

    public void AddExp(int newExp)
    {
        experiance += newExp;
        if(experiance >= expToAdvance)
        {
            LevelUp();
        }
    }
}
