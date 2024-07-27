using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;
    public ItemType itemtype;

    [SerializeField] private Image itemImage;

    [SerializeField] private EquippedSlot headSlot, bodySlot, beltSlot, legSlot, mainHandSlot, offHandSlot, acessSlot, bootSlot;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;
    private EquipmentSOLibrary equipmentSOLibrary;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
    }

    public int AddItem(string ItemName, int quanity, Sprite itemSprite, string itemDescription, ItemType itemType)
    {
        //is Slot full
        if (isFull) { return quanity; }
        //Update Values
        this.itemtype = itemType;
        this.itemName = ItemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;
        //Handle Item Increase
        this.quantity = 1;
        isFull = true;

        return 0;
    }

    public void OnLeftClick()
    {
        if (isFull)
        {
            if (thisItemSelected)
            {
                EquipGear();
            }
            else
            {
                inventoryManager.DeSelectAllSlots();
                selectedShader.SetActive(true);
                thisItemSelected = true;
                for (int i = 0; i < equipmentSOLibrary.equipmentSOs.Length; i++)
                {
                    if (equipmentSOLibrary.equipmentSOs[i].itemName == this.itemName)
                    {
                        equipmentSOLibrary.equipmentSOs[i].PreviewEquipment();
                    }
                }
            }
        }
        else
        {
            GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffPreview();
            inventoryManager.DeSelectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
        }
        
    }

    public void OnRightClick()
    {

    }

    private void EquipGear()
    {
        if (itemtype == ItemType.head)
            headSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.body)
            bodySlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.belt)
            beltSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.legs)
            legSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.mainhand)
            mainHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.offhand)
            offHandSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.acsessory)
            acessSlot.EquipGear(itemSprite, itemName, itemDescription);
        if (itemtype == ItemType.boots)
            bootSlot.EquipGear(itemSprite, itemName, itemDescription);

        EmptySlot();
    }

    public void EmptySlot()
    {
        //quantityText.enabled = false;
        itemImage.sprite = emptySprite;
        isFull = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void ShowItem()
    {
        if (itemImage.sprite != emptySprite)
        {
            itemImage.sprite = itemSprite;
        }
    }
}
