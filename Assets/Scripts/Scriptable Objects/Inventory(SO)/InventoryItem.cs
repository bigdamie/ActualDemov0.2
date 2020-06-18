using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(menuName = "Scriptable Objects/Inventory Item", fileName = "New Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public PhysicalInventoryItem itemPrefab;
    public string myName;
    [TextArea(5,5)]
    public string myDescription;
    public int correctPrice;
    public bool isUsable = false;
    public bool isUnique; 
    public int numberHeld;
    public UnityEvent eventOnUse;
    public UnityEvent otherEvent;

    public void Use() 
    { 
        eventOnUse.Invoke();       
    }

    public void TriggerEvent()
    {
        otherEvent.Invoke();    
    }

    public void DecreaseAmountByOne()
    {
        numberHeld--;
        if(numberHeld <0)
        {
            numberHeld = 0;
        }
    }

    public void IncreaseAmountByOne()
    {
        numberHeld++;
        
    }

    private void OnDisable()
    {
        numberHeld = 0;
    }
}
