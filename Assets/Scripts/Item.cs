using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quanity;
    [SerializeField] private Sprite sprite;
    [TextArea][SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    public ItemType ItemType;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Enter!");
        if (collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quanity, sprite, itemDescription, ItemType);
            if(leftOverItems <= 0)
            {
                Destroy(gameObject);
            } else
            {
                quanity = leftOverItems;
            }
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inventoryManager.AddItem(itemName, quanity, sprite);
            Destroy(gameObject);
        }
    }*/

    public void InteractItem()
    {
        inventoryManager.AddItem(itemName, quanity, sprite, itemDescription, ItemType);
        Destroy(gameObject);
    }
}
