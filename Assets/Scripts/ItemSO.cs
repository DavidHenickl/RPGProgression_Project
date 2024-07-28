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
            GameObject.Find("hero").GetComponent<PlayerManager>().HealDamage(amountToChangeStat);
            return true;
        }
        if (statToChange == StatToChange.mana)
        {
            return true;
        }
        if (statToChange == StatToChange.stamina)
        {
            return true;
        }
        if (attributesToChange == AttributesToChange.health)
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().IncreaseHealth(amountToChangeAttribute);
            return true;
        }
        if (attributesToChange == AttributesToChange.attack)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.attack += amountToChangeAttribute;
            PS.UpdateEquipment();
            return true;
        }
        if (attributesToChange == AttributesToChange.defense)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.defense += amountToChangeAttribute;
            PS.UpdateEquipment();
            return true;
        }
        if (attributesToChange == AttributesToChange.agility)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.agility += amountToChangeAttribute;
            PS.UpdateEquipment();
            return true;
        }
        if (attributesToChange == AttributesToChange.intelligence)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.intelligence += amountToChangeAttribute;
            PS.UpdateEquipment();
            return true;
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
        attack,
        defense,
        agility,
        intelligence
    };
}
