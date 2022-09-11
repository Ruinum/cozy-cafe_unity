using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;

public class Customer : MonoBehaviour
{
    public CustomerText customerText;
    public Task task;
    public float TimeToWait;

    [HideInInspector] public int _Pos;
    
    private Timer _timerToLeave;

    private void Start()
    {
        _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait,Leave); 
    }

    public void AddTask()
    {
        Debug.Log("Task Added");
        if (task.TskNum == 0)task = TaskManager.Singletone.CreateTask(this,TimeToWait);
    }

    public void Leave()
    {
        ReviewsSystem.Singletone.ChangeRating(task.completed ? 2 : -2);
        task = null;
        CustomersSystem.Singletone.CustomerLeave(gameObject);
    }

    public void ResetTimer(float chg)
    {
        TimeToWait -= (_timerToLeave.GetCurrentTime() + chg);
        _timerToLeave.OnTimerEnd -= Leave;
        _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait, Leave);
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
