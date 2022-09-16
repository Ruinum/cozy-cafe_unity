using UnityEngine;
using Ruinum.Core;
using TMPro;

public class MoneySystem : BaseSingleton<MoneySystem>
{
    [SerializeField] private TextMeshProUGUI _textMoneyAmount;

    private int _currentAmount;

    private void Start()
    {
        _textMoneyAmount.text = _currentAmount.ToString();
    }

    public void AddAmount(int amount)
    {
        _currentAmount += amount;
        _textMoneyAmount.text = _currentAmount.ToString();
    }

    public void SubtractAmount(int amount)
    {
        _currentAmount -= amount;
        _textMoneyAmount.text = _currentAmount.ToString();
    }

    public void SubtractAmount(ItemSO item)
    {
        _currentAmount -= item.Cost;
        _textMoneyAmount.text = _currentAmount.ToString();
    }
}
