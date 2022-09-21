using UnityEngine;
using Ruinum.Core;
using TMPro;

public class MoneySystem : BaseSingleton<MoneySystem>
{
    [SerializeField] private TextMeshProUGUI _textMoneyAmount;
    [SerializeField] private GameObject _popupUi;
    [SerializeField] private Transform _transform;

    private int _currentAmount;

    private void Start()
    {
        _textMoneyAmount.text = _currentAmount.ToString();
    }

    public void AddAmount(int amount)
    {
        _currentAmount += amount;
        _textMoneyAmount.text = _currentAmount.ToString();

        CreatePopup($"+{amount}", Color.green);
    }

    public void SubtractAmount(int amount)
    {
        _currentAmount -= amount;
        _textMoneyAmount.text = _currentAmount.ToString();

        CreatePopup($"-{amount}", Color.red);
    }

    public void SubtractAmount(ItemSO item)
    {
        _currentAmount -= item.Cost;
        _textMoneyAmount.text = _currentAmount.ToString();

        CreatePopup($"-{item.Cost}", Color.red);
    }

    private void CreatePopup(string value, Color color)
    {
        var text = Instantiate(_popupUi, _transform).GetComponent<TMP_Text>();
        text.text = value;
        text.color = color;
    }
}
