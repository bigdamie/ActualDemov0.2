using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATM : Interactable
{
    [SerializeField] Notification GetMoneyNotification;
    [SerializeField] MoneyDisplayManager wallet;

    private void OnEnable()
    {
        wallet = FindObjectOfType<MoneyDisplayManager>();
    }

    private void Update()
    {
        if(playerInRange && Input.GetButtonDown("Check"))
        {
            GetMoneyNotification.Raise();
            wallet.AddMoney(10);
        }
    }
}
