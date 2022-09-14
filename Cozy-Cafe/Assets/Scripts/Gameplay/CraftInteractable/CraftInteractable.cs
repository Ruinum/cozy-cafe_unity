using Ruinum.Core;
using UnityEngine;

using System;
using System.Collections.Generic;


public class CraftInteractable : MonoBehaviour
{
    [SerializeField] private float _craftTime;
    [SerializeField] private ReceptSO[] _recepts;

    private ItemSO _currentCraftedItem;
    private Timer _timer;

    private List<ItemSO> _currentItems = new List<ItemSO>();

    private Action<ItemSO> _onCraftComplete;

    public bool TryCraftItem(ItemSO itemSO)
    {
        if (_currentCraftedItem != null) return false;
        if (_timer != null) return false;

        _currentItems.Add(itemSO);

        for (int i = 0; i < _recepts.Length; i++)
        {
            if (_recepts[i].CheckEquality(_currentItems.ToArray())) { _currentItems.Clear(); _onCraftComplete?.Invoke(_recepts[i].ResultItem); return true; }
        }

        return false;
    }

    public void ClearCurrentItems()
    {
        _currentItems.Clear();
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
