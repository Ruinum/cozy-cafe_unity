using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using Articy.Unity.Interfaces;
using UnityEngine;
using Ruinum.Core;

public class RandomCustomer : Customer {
    //public CustomerDialogue customerDialogue;

    private Timer _timerToLeave;
    
    //private void Start() {
    //    taskadd += RandomTask;
    //    _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait, Leave);
    //}

    public void RandomTask()
    {
        task = TaskManager.Singleton.CreateTask(this, TimeToWait);
    }

    public void ResetTimer(float chg) {
        TimeToWait -= (_timerToLeave.GetCurrentTime() + chg);
        _timerToLeave.OnTimerEnd -= Leave;
        _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait, Leave);
    }
}

//[System.Serializable]
//public class CustomerDialogue {
//    [SerializeField] private List<ArticyReference> availableDialogues;
//    private int currentDialogueIndex;

//    public ArticyObject GetDialogue() {
//        return currentDialogueIndex < availableDialogues.Capacity
//            ? availableDialogues[currentDialogueIndex++].reference.GetObject()
//            : null;
//    }
//}