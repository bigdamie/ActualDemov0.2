using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DisplayCase : Interactable
{
    [SerializeField] InventoryItem itemSO;
    [SerializeField] Inventory playerInventory, shopInventory;
    [SerializeField] InventoryManager invMan;
    [SerializeField] GameObject  player;
    [SerializeField] public PhysicalInventoryItem itemDisplayed,tempHold;


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            playerInRange = true;


            foreach (InventoryItem item in playerInventory.myInventory)
            {
                item.isUsable = playerInRange;
            }



            myNotification.Raise();
        }
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {
            playerInRange = false;
           
            foreach (InventoryItem item in playerInventory.myInventory)
            {
                item.isUsable = playerInRange;
            }

            myNotification.Raise();
        }
    }

    public void PlaceItem()
    {


        if (playerInRange)
        {


            itemSO = invMan.currItem;

            if (itemSO)     
            {
                Debug.Log(itemSO.name);

                itemDisplayed = Instantiate(itemSO.itemPrefab,
                                            itemDisplayed.transform);

                itemSO.itemPrefab?.AddItemToInventory(shopInventory);
                itemDisplayed.RemoveItemFromInventory(playerInventory);


            }
        }

    }

    public void RetrieveItem()
    {

        if (playerInRange && itemDisplayed)
        {
            if (itemDisplayed.GetComponent<PhysicalInventoryItem>())
            {

                Debug.Log("brt");
                
               

                Debug.Log(itemDisplayed.thisItem.name);
                
                itemDisplayed?.AddItemToInventory(playerInventory);
                
                itemDisplayed?.RemoveItemFromInventory(shopInventory);

                itemDisplayed.thisItem.DecreaseAmountByOne();

                Destroy(itemDisplayed.gameObject);

                itemDisplayed = tempHold;
                
            }
            else
                Debug.Log("itemDisplayed.GetComponent<InventoryItem>()\n returns false.");


        }
       
    }

    void Update()
    {

        if (playerInRange)
        {
            if (Input.GetButtonDown("Check"))
            {
                RetrieveItem();
            }
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

}
