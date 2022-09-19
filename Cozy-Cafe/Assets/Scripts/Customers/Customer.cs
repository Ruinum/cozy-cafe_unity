using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    public Task task;
    public float TimeToWait;
    public int score = 2;
    public UnityAction taskadd;

    public void Leave()
    {
        ReviewsSystem.Singletone.ChangeRating(task.completed ? score : -score);
        task = null;
        CustomersSystem.Singletone.CustomerLeave(gameObject);
    }
    public void AddTask()
    {
        if (task.TskNum == 0) taskadd?.Invoke();
    }
    private void OnMouseDown()
    {
        AddTask();
    }
}
