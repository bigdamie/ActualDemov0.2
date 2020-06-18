using UnityEngine;
using TMPro;

public class MoneyDisplayManager : PlayerMoney
{
    [SerializeField] TextMeshProUGUI displayText;

    public void UpdateMoneyDisplay()
    {
        displayText.text = currentMoney.value.ToString();
    }

    private void OnEnable()
    {
        UpdateMoneyDisplay();
    }
}
