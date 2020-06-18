using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] TextMeshProUGUI itemNumberText;
    [SerializeField] Image itemImage;

    [Header("Variables from the item")]
    
    public InventoryItem thisItem;
    public InventoryManager thisMan;

    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisMan = newManager;
        if(thisItem)
        {
            itemImage.sprite = thisItem.itemPrefab.GetComponent<SpriteRenderer>().sprite;
            itemNumberText.text = "" + thisItem.numberHeld;
        }
    }

    public void ClickedOn()
    {
        if(thisItem)
        {
            thisMan.SetupDescAndButton(thisItem.myDescription, thisItem.isUsable, thisItem);
        }
    }
}
