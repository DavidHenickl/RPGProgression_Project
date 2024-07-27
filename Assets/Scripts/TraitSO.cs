using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemSO;

[CreateAssetMenu]
public class TraitSO : ScriptableObject
{
    public string traitName;

    public Dialog description;

    public int amountToChange;

    public AttributesToChange statToChange;

    public void Activate()
    {
        if (statToChange == AttributesToChange.health)
        {
            GameObject.Find("Player").GetComponent<PlayerManager>().IncreaseHealth(amountToChange);
        }
        if (statToChange == AttributesToChange.attack)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.attack += amountToChange;
            PS.UpdateEquipment();
        }
        if (statToChange == AttributesToChange.defense)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.defense += amountToChange;
            PS.UpdateEquipment();
        }
        if (statToChange == AttributesToChange.agility)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.agility += amountToChange;
            PS.UpdateEquipment();
        }
        if (statToChange == AttributesToChange.intelligence)
        {
            PlayerStats PS = GameObject.Find("StatManager").GetComponent<PlayerStats>();
            PS.intelligence += amountToChange;
            PS.UpdateEquipment();
        }
        DisplayText();
    }

    private void DisplayText()
    {
        //Show Dialog
        DialogeRoutine.instance.StartCoroutine(DialogManager.instance.ShowDialog(description));


    }

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

public class DialogeRoutine : MonoBehaviour
{
    public static DialogeRoutine instance;

    void Start()
    {
        DialogeRoutine.instance = this;
    }
}
