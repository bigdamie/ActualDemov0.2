using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public Inventory playerInventory;
    [SerializeField] GameObject emptyInventorySlot;
    [SerializeField] GameObject inventoryScrollViewContent;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] GameObject useButton;
    public InventoryItem currItem;

    public void SetTextAndButton(string desc, bool buttonActive)
    {
        descText.text = desc;
        if(buttonActive)
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    void MakeInventorySlots()
    {
        if(playerInventory)
        {
            for(int i=0; i<playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0)
                {
                    GameObject temp = Instantiate(
                         emptyInventorySlot, inventoryScrollViewContent.transform.position
                         , Quaternion.identity);
                    temp.transform.SetParent(inventoryScrollViewContent.transform);

                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();

                    if (newSlot)
                    {
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }


    public void SetupDescAndButton(string newDesc, bool isButtonUsable,InventoryItem newItem)
    {
        currItem = newItem;
        descText.text = newDesc;
        useButton.SetActive(isButtonUsable);
    }

    void ClearInventorySlots()
    {
        for(int i=0; i < inventoryScrollViewContent.transform.childCount;i++)
        {
            Destroy(inventoryScrollViewContent.transform.GetChild(i).gameObject);
        }
    }

    public void UseButtonPressed()
    {
        currItem.Use();

        ClearInventorySlots();

        MakeInventorySlots();
       
        if (currItem.numberHeld == 0)
        {
            SetTextAndButton("", false);
        }
    }
    private void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

}
