using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class EquippedSlot : MonoBehaviour, IPointerClickHandler
{
    //Apperance
    [SerializeField] private Image slotImage;
    [SerializeField] private TMP_Text slotName;
    //Data
    [SerializeField] private ItemType ItemType = new ItemType();
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;
    //Other
    private bool slotInUse;

    [SerializeField] public GameObject selectedShader;
    [SerializeField] public bool thisItemSelected;
    [SerializeField] public Sprite emptySprite;

    private InventoryManager inventoryManager;
    private EquipmentSOLibrary equipmentSOLibrary;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        equipmentSOLibrary = GameObject.Find("InventoryCanvas").GetComponent<EquipmentSOLibrary>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    void OnLeftClick()
    {
        if(thisItemSelected && slotInUse)
        {
            UnEquipGear();
        } else
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
    void OnRightClick()
    {
        UnEquipGear();
    }

    public void EquipGear(Sprite itemSprite, string itemName, string itemDescription)
    {
        if (slotInUse)
            UnEquipGear();

        this.itemSprite = itemSprite;
        slotImage.sprite = itemSprite;
        slotName.enabled = false;

        this.itemName = itemName;
        this.itemDescription = itemDescription;

        for (int i = 0; i < equipmentSOLibrary.equipmentSOs.Length; i++)
        {
            if (equipmentSOLibrary.equipmentSOs[i].itemName == this.itemName)
            {
                equipmentSOLibrary.equipmentSOs[i].EquipItem();
            }
        }  

        slotInUse = true;
    }

    public void UnEquipGear()
    {
        inventoryManager.DeSelectAllSlots();

        inventoryManager.AddItem(itemName, 1, itemSprite, itemDescription, ItemType);

        this.itemSprite = emptySprite;
        slotImage.sprite = this.emptySprite;
        slotName.enabled = true;

        for (int i = 0; i < equipmentSOLibrary.equipmentSOs.Length; i++)
        {
            if (equipmentSOLibrary.equipmentSOs[i].itemName == this.itemName)
            {
                equipmentSOLibrary.equipmentSOs[i].UnEquipItem();
            }
        }

        GameObject.Find("StatManager").GetComponent<PlayerStats>().TurnOffPreview();
    }
}
