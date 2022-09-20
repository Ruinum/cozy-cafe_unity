using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;
using Ruinum.Core;
using TMPro;

public class Customer : Executable {
    public CustomerDialogue customerDialogue = new CustomerDialogue();
    public Task task = null;
    public float TimeToWait;
    public float MinChangeTime;
    public float MaxChangeTime;

    [SerializeField] private ArticyRef[] _articyRefs;
    [SerializeField] private GameObject _orderBubble;
    [SerializeField] private List<TextMeshProUGUI> _bubbleTextComponents;
    [SerializeField] private RectTransform patienceMeter;

    [HideInInspector] public int _Pos;

    private Timer _timerToLeave;
    private bool _isTaskCreated = false;

    public override void Start() {
        base.Start();

        TimeToWait += Random.Range(MinChangeTime, MaxChangeTime);
        _timerToLeave = TimerManager.Singleton.StartTimer(TimeToWait, Leave);
        GameManager.Singleton.AddExecuteObject(this);        
    }

    public override void Execute() {
        patienceMeter.sizeDelta = new Vector2(_timerToLeave.GetCurrentTime() / TimeToWait * 3, 0.25f);
    }

    public void AddTask() {
        if (!_isTaskCreated) {
            task = TaskManager.Singleton.CreateTask(this, TimeToWait);
            task.OnTaskCompleteEvent += Leave;

            _isTaskCreated = true;
            InitializeTaskUI();
        }
    }

    private void InitializeTaskUI() {
        _orderBubble.SetActive(true);
        //0 - coffee; 1 - syrup; 2 - topping; 3-4 - dessert
        bool hasDessert = false;
        foreach (var dish in task.Dish) {
            if (dish.Item.IsSyrup) {
                _bubbleTextComponents[1].gameObject.SetActive(true);
                _bubbleTextComponents[1].text = "- " + dish.Item.Name;
            } else if (dish.Item.IsTopping) {
                _bubbleTextComponents[2].gameObject.SetActive(true);
                _bubbleTextComponents[2].text = "- " + dish.Item.Name;
            } else if (dish.Item.IsDessert) {
                if (!hasDessert) {
                    _bubbleTextComponents[3].gameObject.SetActive(true);
                    _bubbleTextComponents[3].text = dish.Item.Name;
                    hasDessert = true;
                }
                else {
                    _bubbleTextComponents[4].gameObject.SetActive(true);
                    _bubbleTextComponents[4].text = dish.Item.Name;
                }
            }
            else {
                _bubbleTextComponents[0].gameObject.SetActive(true);
                _bubbleTextComponents[0].text = dish.Item.Name;
            }
        }
    }

    public void Leave() {
        ReviewsSystem.Singletone.ChangeRating(task.completed ? 2 : -2);
        CustomersSystem.Singleton.CustomerLeave(gameObject);
        GameManager.Singleton.RemoveExecuteObject(this);


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

    internal void InitializeDialogue() {
        customerDialogue.Initialize(_articyRefs);
    }
}

public class CustomerDialogue {
    private List<ArticyRef> availableDialogues = new List<ArticyRef>();
    private int currentDialogueIndex;

    public void Initialize(ArticyRef[] articyRefs) {
        for (int i = 0; i < articyRefs.Length; i++) {
            availableDialogues.Add(articyRefs[i]);
        }
    }

    public ArticyObject GetDialogue() {
        return currentDialogueIndex < availableDialogues.Capacity
            ? availableDialogues[currentDialogueIndex++].GetObject()
            : null;
    }
}