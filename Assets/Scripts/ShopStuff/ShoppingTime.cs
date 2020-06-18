using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingTime : MonoBehaviour
{
    public bool shopping;
    public float shoppingTime;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject timerObject;
    [SerializeField] Notification closeShopNotification;
    

    public void OnEnable()
    {
        shopping = true;
        timerObject.SetActive(true);
        timeText.text = shoppingTime.ToString("F2");


    }


    private void Update()
    {
        if (shopping)
        {
            timeText.text = shoppingTime.ToString("F2");


            if (shoppingTime >= 0)
                shoppingTime -= Time.deltaTime;

            if (shoppingTime <= 0.1)
            {
                shoppingTime = 0;
                closeShopNotification.Raise();
                shopping = false;


                this.gameObject.SetActive(false);
            }
        }
        else
            closeShopNotification.Raise();

    }
}
