using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public bool canSwitch;
    public bool hasBeenSwitched;
    [SerializeField] public Notification switchNotification, secondNotification;
    [SerializeField] public Sprite left, right;
    [SerializeField] public SpriteRenderer spRend;

    private void Update()
    {
        if (Input.GetButtonDown("Check") && playerInRange)
        {
            SwitchTheSwitch();
        }
    }

    public virtual void SwitchTheSwitch()
    {
        hasBeenSwitched = true;

        if (canSwitch)
            switchNotification.Raise();

        if (hasBeenSwitched && secondNotification)
            secondNotification.Raise();


        if (spRend.sprite == left)

            spRend.sprite = right;
        else if (spRend.sprite == right)
            spRend.sprite = left;

       
    }
}
