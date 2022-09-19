using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task 
{
    public bool completed;
    private Customer customer;

    public int TskNum;
    public float Duration;

    public List<Dish> Dish = new List<Dish>();

    public void AddItem(ItemSO item)
    {
        for (int i = 0; i < Dish.Count; i++)
        {
            if (item == Dish[i].Item)
            {
                Dish[i]._isHave = true;
                break;
            }
        }
    }
    public Customer Owner(Customer c = null)
    {
        if (c) customer = c;
        return customer;
    }
}

