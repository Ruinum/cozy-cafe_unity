using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;
using Ruinum.Core;

public class Customer : MonoBehaviour {
    public CustomerDialogue customerDialogue;
    public Task task = null;
    public float TimeToWait;

    [SerializeField] private ArticyRef[] _articyRefs;
    [HideInInspector] public int _Pos;

    private Timer _timerToLeave;

    private void Start() {        
        _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait, Leave);
    }

    public void AddTask() {
        if (task == null) task = TaskManager.Singletone.CreateTask(this, TimeToWait);
    }

    public void Leave() {
        ReviewsSystem.Singletone.ChangeRating(task.completed ? 2 : -2);
        CustomersSystem.Singleton.CustomerLeave(gameObject);

        task = null;
    }

    public void ResetTimer(float chg) {
        TimeToWait -= (_timerToLeave.GetCurrentTime() + chg);
        _timerToLeave.OnTimerEnd -= Leave;
        _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait, Leave);
    }

    private void OnMouseDown() {
        AddTask();
    }

    internal void InitializeDialogue()
    {
        customerDialogue.Initialize(_articyRefs);
    }
}

[System.Serializable]
public class CustomerDialogue {
    [SerializeField] private List<ArticyRef> availableDialogues;
    private int currentDialogueIndex;

    public void Initialize(ArticyRef[] articyRefs)
    {
        for (int i = 0; i < articyRefs.Length; i++)
        {
            availableDialogues.Add(articyRefs[i]);
        }
    }

    public ArticyObject GetDialogue() {
        return currentDialogueIndex < availableDialogues.Capacity
            ? availableDialogues[currentDialogueIndex++].GetObject()
            : null;
    }
}