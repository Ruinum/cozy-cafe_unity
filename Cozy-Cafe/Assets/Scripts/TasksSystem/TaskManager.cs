using System.Collections.Generic;
using UnityEngine;

using Ruinum.Utils;
using Ruinum.Core;


public class TaskManager : BaseSingleton<TaskManager>
{
    public List<ScriptableObject> Cofee = new List<ScriptableObject>();
    public List<ScriptableObject> Items = new List<ScriptableObject>();
    [Range(1, 3)] private int TasksNum = 1;

    public float MinChangeTime;
    public float MaxChangeTime;


    private void Start()
    {
        Cofee.AddRange(Resources.LoadAll<ScriptableObject>("ScriptableObjects/Items/Drinks"));

        Items.AddRange(Resources.LoadAll<ScriptableObject>("ScriptableObjects/Items/Dishes"));
        Items.AddRange(Resources.LoadAll<ScriptableObject>("ScriptableObjects/Items/Syrups"));
        Items.AddRange(Resources.LoadAll<ScriptableObject>("ScriptableObjects/Items/Toppings"));
    }

    int hardest; //1-3 repeats
    public Task CreateTask(Customer customer,float TimeChangeValue)
    {
        Task _task = new Task();
        _task.Owner(customer);
        hardest = GiveDifficult();

        _task.Dish.Add(new Dish());
        _task.Dish[0].Item = AddItem(Cofee);

        for (int i = 1; i <= hardest; i++)
        {
            _task.Dish.Add(new Dish());
            _task.Dish[i].Item = AddItem(Items);
        }
        _task.TskNum = TasksNum;
        TasksNum++;
        _task.Owner().TimeToWait += Random.Range(MinChangeTime, MinChangeTime);
        return _task;
    }

    public ItemSO AddItem(List<ScriptableObject> items)
    {
        return (ItemSO)RandomExtentions.RandomList(items);
    }

    private int GiveDifficult()
    {
        if (RandomExtentions.RandomLess(0.8f))
        {
            return 1;
        }else if (RandomExtentions.RandomLess(0.5f))
        {
            return 2;
        }
        else
        {
            return 3;
        }
    }
}

