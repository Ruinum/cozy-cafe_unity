using System.Collections;
using System.Collections.Generic;
using Ruinum.Core;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public CustomerText customerText;
    public Task task;
    public float TimeToWait;
   private Timer _timerToLeave;

    private void Start()
    {
    _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait,Leave);
    }

    public void AddTask()
    {
        if (task == null)task = TaskManager.Singletone.CreateTask(TimeToWait);
    }

    public void Leave()
    {
        ReviewsSystem.Singletone.ChangeRating(task.completed ? 2 : -2);
        task = null;
    }

    private void OnMouseDown()
    {
        AddTask();
    }
}
[System.Serializable]

public class CustomerText
{
    public string FirstPgrase;
}
