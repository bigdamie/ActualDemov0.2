using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSwitch : Switch
{

    public override void SwitchTheSwitch()
    {

        if (canSwitch && !hasBeenSwitched)
        {          
            switchNotification.Raise();
            hasBeenSwitched = true;

        }

        else if (hasBeenSwitched && secondNotification != null)
        {
            secondNotification.Raise();
            hasBeenSwitched = false;
        }


        if (spRend.sprite == left)

            spRend.sprite = right;
        else if (spRend.sprite == right)
            spRend.sprite = left;


    }


}
