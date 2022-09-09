using System;
using UnityEngine;


public class CraftInteractable : MonoBehaviour
{
    [SerializeField] private float _craftTime;
    [SerializeField] private ReceptSO[] _recepts;

    private ItemSO _currentItem;
    private Timer _timer;

    private Action<ItemSO> _onCraftComplete;

    public bool TryCraftItem(ItemSO itemSO)
    {
        if (_currentItem != null) return false;
        if (_timer != null) return false;

        for (int i = 0; i < _recepts.Length; i++)
        {
            if (_recepts[i].RequestItem != itemSO) continue;

            var recept = _recepts[i];

            _timer = TimerManager.Singleton.StartTimer(_craftTime, () => { _currentItem = recept.ResultItem; _onCraftComplete?.Invoke(_currentItem); });

            return true;
        }

        return false;
    }

    public void AddListener(Action<ItemSO> listener)
    {
        _onCraftComplete += listener;
    }

    public void RemoveListener(Action<ItemSO> listener)
    {
        _onCraftComplete -= listener;
    }
}
