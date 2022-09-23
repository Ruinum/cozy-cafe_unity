using Articy.Unity;
using DialogueSystem;
using UnityEngine;

public class SpecialCustomer : Customer {
    
    [SerializeField] private SpecialCustomerSO data;

    private bool dialogueStarted;


    private new void Start() {
        //Remove after tests
        data.ordersNumber = 0;
        
        base.Start();
    }

    protected override void AddTask() {
        if (_isTaskCreated) return;
        
        if(data.tasks.Count == 0) base.AddTask();
        else {
            task = data.tasks[0];
            data.tasks.RemoveAt(0);
            
            _isTaskCreated = true;

            InitializeTaskUI();
        }
    }

    private ArticyObject GetDialogue() {
        return data.ordersNumber < data.dialogues.Count
            ? data.dialogues[data.ordersNumber++].GetObject()
            : null;
    }

    private void OnMouseDown() {
        if (dialogueStarted) return;
        dialogueStarted = true;
        
        Time.timeScale = 0;

        DialogueManager.Singleton.StartDialogue(GetDialogue(), this);
    }

    public void SetTask() {
        Time.timeScale = 1;
        
        AddTask();
    }
}