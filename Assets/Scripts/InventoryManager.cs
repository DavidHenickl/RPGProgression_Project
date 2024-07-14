using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject EquipmentMenu;
    public ItemSlot[] itemSlot;
    public EquipmentSlot[] equipmentSlot;
    public EquippedSlot[] equippedSlots;

    public ItemSO[] itemSOs;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Inventory();
        }
        if (Input.GetButtonDown("Equipment"))
        {
            Equipment();
        }
        
    }

    void Inventory()
    {
        if (InventoryMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            EquipmentMenu.SetActive(false);
        }
    }
    void Equipment()
    {
        if (EquipmentMenu.activeSelf)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(false);
            EquipmentMenu.SetActive(true);
        }
    }

    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSlot.Length; i++) 
        { 
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }
        }
        return false;
    }

    public int AddItem(string ItemName, int quanity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        if(itemType == ItemType.consumable || itemType == ItemType.craftable || itemType == ItemType.collectable)
        {
            for (int i = 0; i < itemSlot.Length; i++)
            {
                if (itemSlot[i].isFull == false && itemSlot[i].itemName == ItemName || itemSlot[i].quantity == 0)
                {
                    int leftOverItems = itemSlot[i].AddItem(ItemName, quanity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(ItemName, leftOverItems, itemSprite, itemDescription, itemType);
                    }
                    return leftOverItems;
                }
            }
            return quanity;
        } else
        {
            for (int i = 0; i < equipmentSlot.Length; i++)
            {
                if (equipmentSlot[i].isFull == false && equipmentSlot[i].itemName == ItemName || equipmentSlot[i].quantity == 0)
                {
                    int leftOverItems = equipmentSlot[i].AddItem(ItemName, quanity, itemSprite, itemDescription, itemType);
                    if (leftOverItems > 0)
                    {
                        leftOverItems = AddItem(ItemName, leftOverItems, itemSprite, itemDescription, itemType);
                    }
                    return leftOverItems;
                }
            }
            return quanity;
        }
    }

    public void DeSelectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equipmentSlot.Length; i++)
        {
            equipmentSlot[i].selectedShader.SetActive(false);
            equipmentSlot[i].thisItemSelected = false;
        }
        for (int i = 0; i < equippedSlots.Length; i++)
        {
            equippedSlots[i].selectedShader.SetActive(false);
            equippedSlots[i].thisItemSelected = false;
        }
    }
}

public enum ItemType
{
    consumable,
    craftable,
    collectable,
    head,
    body,
    belt,
    legs,
    mainhand,
    offhand,
    acsessory,
    boots,
    none
};
