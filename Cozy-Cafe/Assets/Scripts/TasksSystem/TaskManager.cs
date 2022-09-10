using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Utils;


public class TaskManager : MonoBehaviour
{
    public static TaskManager Singletone;

    public List<ScriptableObject> Items = new List<ScriptableObject>();
    [Range(1, 3)] private int TasksNum = 1;

    public float MinChangeTime;
    public float MaxChangeTime;


    private void Awake()
    {
        Singletone = this;
        Items.AddRange(Resources.LoadAll<ScriptableObject>("ScriptableObjects/Items"));
    }

    int hardest; //1-3 repeats
    public Task CreateTask(Customer customer,float TimeChangeValue)
    {
        Task _task = new Task();
        _task.Owner(customer);
        hardest = GiveDifficult();
        for (int i = 0; i < hardest; i++)
        {
            _task.Dish.Add(new Dish());
            _task.Dish[i].Item = AddItem();
        }
        _task.TskNum = TasksNum;
        TasksNum++;
        _task.Owner().TimeToWait += Random.Range(MinChangeTime, MinChangeTime);
        return _task;
    }

    public ItemSO AddItem()
    {
        return (ItemSO)RandomExtentions.RandomList(Items);
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

