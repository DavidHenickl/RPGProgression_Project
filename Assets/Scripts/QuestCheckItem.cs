using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCheckItem : MonoBehaviour
{
    [SerializeField] string ItemName;
    [SerializeField] int amount;

    [SerializeField] ReputationGroup.RepGroups repGroup;
    [SerializeField] int repToAdd;

    private InventoryManager inventoryManager;
    private ReputationManager reputationManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        reputationManager = GameObject.Find("StatManager").GetComponent<ReputationManager>();
    }

    public bool CheckCondidtion()
    {
        if(inventoryManager.CheckItemAmount(ItemName) >= amount)
        {
            for(int i = 0; i < amount; i++)
            {
                inventoryManager.DeleteItem(ItemName);
            }
            //Give positive Outcome
            reputationManager.AddRep(repGroup.ToString(), repToAdd);
            return true;
        }
        //Nagative outcome
        return false;
    }
}
