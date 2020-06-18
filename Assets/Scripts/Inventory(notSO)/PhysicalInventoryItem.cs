using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] public InventoryItem thisItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !collision.isTrigger)
        {
            AddItemToInventory(playerInventory);
            Destroy(this.gameObject);
        }
    }


    public void AddItemToInventory(Inventory inventory)
    {

        if (inventory && thisItem)
        {
            inventory.AddItem(thisItem);
        }
    }

    public void RemoveItemFromInventory(Inventory inventory)
    {
        if (inventory && thisItem)
        {
            if (inventory.myInventory.Contains(thisItem))
            {
                inventory.RemoveItem(thisItem);
            }
            else
            {
                Debug.Log("apparently, this inventory doesn't have that item to remove.");
            }
        }
    }
}
