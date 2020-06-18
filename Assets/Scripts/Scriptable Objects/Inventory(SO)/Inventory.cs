using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName ="Inventory/Player Inventory", fileName ="New Player Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> myInventory = new List<InventoryItem>();
    [SerializeField] Notification itemUsedNotification;

    public void AddItem(InventoryItem newItem)
    {
        if (!myInventory.Contains(newItem))
        {
            myInventory.Add(newItem);
        }

        newItem.numberHeld++;
    }

    public void RemoveItem(InventoryItem newItem)
    {
        if (myInventory.Contains(newItem))
        {
            myInventory.Remove(newItem);
        }
    }

    public void UseItem(InventoryItem newItem)
    {
        itemUsedNotification.Raise();

        if(myInventory.Contains(newItem))
        {
            if (newItem.numberHeld > 0)
            {
                newItem.numberHeld--;
            }
            else
                RemoveItem(newItem);
        }
    }

    public bool IsItemInInventory(InventoryItem newItem)
    {
        return myInventory.Contains(newItem);
    }

    public bool canUseItem(InventoryItem newItem)
    {
        return newItem.numberHeld > 0;
    }
}
