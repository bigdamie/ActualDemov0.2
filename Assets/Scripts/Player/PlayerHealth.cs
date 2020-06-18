using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private FlashColor flash;
    [SerializeField] private FloatValue maxHealthValue;
    [SerializeField] private FloatValue currentHealthValue;
    [SerializeField] private Notification updateHeartsUI;

    //For testing purposes, I'll be setting currenHealthValue manually.
    //In real life, this will have to be initialized at the beginning of
    //the game, and that's the only time!
    private void Start()
    {
        SetHealth((int)maxHealthValue.value);
        //currentHealthValue.value = maxHealthValue.value;
        updateHeartsUI.Raise();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        currentHealthValue.value -= damage;
        updateHeartsUI.Raise();
        if(currentHealth > 0)
        {
            if (flash)
            {
                flash.StartFlash();
            }
        }
    }
}
