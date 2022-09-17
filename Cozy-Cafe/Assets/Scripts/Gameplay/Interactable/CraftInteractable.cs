using Ruinum.Core;
using UnityEngine;

using System;
using System.Collections.Generic;


public class CraftInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private float _craftTime;
    [SerializeField] private ReceptSO[] _recepts;

    private ItemSO _currentCraftedItem;
    private Timer _timer;

    private List<ItemSO> _currentItems = new List<ItemSO>();

    private Action<ItemSO> _onCraftComplete;
    private Action _onItemTaken;

    public bool TryCraftItem(ItemSO itemSO)
    {
        if (_currentCraftedItem != null) return false;
        if (_timer != null) return false;

        _currentItems.Add(itemSO);

        for (int i = 0; i < _recepts.Length; i++)
        {
            if (_recepts[i].CheckEquality(_currentItems.ToArray())) 
            {
                _currentCraftedItem = _recepts[i].ResultItem;
                
                _currentItems.Clear(); 
                _onCraftComplete?.Invoke(_recepts[i].ResultItem);                 
                return true; 
            }
        }

        return false;
    }

    public void ClearCurrentItems()
    {
        _currentItems.Clear();
        _currentCraftedItem = null;
    }

    public void AddListener(Action<ItemSO> onCraftedItem, Action onItemTaken)
    {
        _onCraftComplete += onCraftedItem;
        _onItemTaken += onItemTaken;
    }

    public void RemoveListener(Action<ItemSO> onCraftedItem, Action onItemTaken)
    {
        _onCraftComplete -= onCraftedItem;
        _onItemTaken -= onItemTaken;
    }

    public void LeftMouseInteract()
    {
        if (_currentCraftedItem == null)
        {
            
        }
        else
        {

        }

        //InventorySystem code goes here


        _onItemTaken?.Invoke();
    }

    public void RightMouseInteract()
    {
        ClearCurrentItems();
    }
}
