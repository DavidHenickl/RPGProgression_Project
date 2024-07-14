using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName; 

    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributesToChange attributesToChange = new AttributesToChange();
    public int amountToChangeAttribute;

    public bool UseItem()
    {
        if (statToChange == StatToChange.health)
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().HealDamage(amountToChangeStat);
            return true;
        }
        if (statToChange == StatToChange.mana)
        {
            
        }
        if (statToChange == StatToChange.stamina)
        {
            //GameObject.Find("HealthManager").GetComponent<Playerhealth>;
        }
        if (attributesToChange == AttributesToChange.health)
        {
            //GameObject.Find("HealthManager").GetComponent<Playerhealth>;
        }
        if (attributesToChange == AttributesToChange.mana)
        {
            //GameObject.Find("HealthManager").GetComponent<Playerhealth>;
        }
        if (attributesToChange == AttributesToChange.stamina)
        {
            //GameObject.Find("HealthManager").GetComponent<Playerhealth>;
        }
        return false;
    }

    public enum StatToChange
    {
        None,
        health,
        mana,
        stamina
    };
    public enum AttributesToChange
    {
        None,
        health,
        mana,
        stamina
    };
}
