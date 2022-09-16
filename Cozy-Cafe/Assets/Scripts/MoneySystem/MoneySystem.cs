using UnityEngine;
using Ruinum.Core;
using TMPro;

public class MoneySystem : BaseSingleton<MoneySystem>
{
    [SerializeField] TextMeshProUGUI textMoneyAmount;

    private int currentAmount;

    private void Start()
    {
        textMoneyAmount.text = currentAmount.ToString();
    }

    public void AddAmount(int amount)
    {
        currentAmount += amount;
        textMoneyAmount.text = currentAmount.ToString();
    }

    public void SubtractAmount(int amount)
    {
        currentAmount -= amount;
        textMoneyAmount.text = currentAmount.ToString();
    }

    public void SubtractAmount(ItemSO item)
    {
        currentAmount -= item.Cost;
        textMoneyAmount.text = currentAmount.ToString();
    }
}
