using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public Sprite unitSprite;

    public int damage;

    public int MaxHP;
    public int currentHP;

    public int expOnDeath;
    public int repOnDeath;

    public ReputationGroup.RepGroups giveRepGroup;

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        return false;
    }

}
