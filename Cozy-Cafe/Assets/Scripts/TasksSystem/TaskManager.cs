using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Singletone;

    public List<ScriptableObject> Items = new List<ScriptableObject>();
    [Range(1, 3)] private int TasksNum = 1;

    private void Awake()
    {
        Singletone = this;
        Items.AddRange(Resources.LoadAll<ScriptableObject>("ScriptableObjects/Items"));
    }

    public Task CreateTask(float TimeChangeValue)
    {
        Task _task = new Task();
        _task.Dish.Add(new Dish());
        _task.Dish[0].Item = AddItem();
        _task.TskNum = TasksNum;
        TasksNum++;
        return _task;
    }

    public ItemSO AddItem()
    {
        return (ItemSO)Items[0];
    }
}
