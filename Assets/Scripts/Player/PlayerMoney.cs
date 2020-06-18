using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] public IntegerValue currentMoney;
    [SerializeField] private int maxMoney;
    [SerializeField] Notification updateMoneyUI;


    public void AddMoney(int amountToAdd)
    {       
        currentMoney.value += amountToAdd;
        updateMoneyUI.Raise();

        if (currentMoney.value >= maxMoney)
        {
            currentMoney.value = maxMoney;
           
        }
    }


    public bool CanAfford(int price)
    {
        return (currentMoney.value >= price);
    }


    public void SubtractMoney(int amountToTake)
    {
        currentMoney.value -= amountToTake;
        updateMoneyUI.Raise();
    }
}
