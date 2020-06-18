using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
   [SerializeField] List<DisplayCase> displayCases = new List<DisplayCase>();
    [SerializeField] float waitTime;
    int displayCaseToPick;
    [SerializeField] float  minWait,maxWait;
    [SerializeField] MoneyDisplayManager moneyMan;
    [SerializeField] Inventory shopInventory;


    private void Start()
    {
        waitTime = 2;
    }

    private void Update()
    {
        if (shopInventory.myInventory.Count > 0)
            ConsiderPurchase();

        else
            Debug.Log("Sold Everything!");

        waitTime -= Time.deltaTime;

        Debug.Log(displayCaseToPick);

    }

    public void ConsiderPurchase()
    {
        Debug.Log("considerPurchase called");

        for (int i = 0; i < displayCases.Count; i++)
        {

            displayCaseToPick = Random.Range(0, displayCases.Count);

            if (waitTime <= 0)
            if( i == displayCaseToPick)
            {
            waitTime = Random.Range(minWait, maxWait);

            PurchaseItem(i);
            }
        }
    }

    public void PurchaseItem(int i)
    {
        Debug.Log("Purchase called");

        if(displayCases[i].itemDisplayed)
        moneyMan.AddMoney(displayCases[i].itemDisplayed.thisItem.correctPrice);

        displayCases[i].itemDisplayed.RemoveItemFromInventory(shopInventory);
 
       
    }
}
