using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;

public class SpecialCustomer : Customer {
    
    [SerializeField] private SpecialCustomerSO data;

    private new void Start() {
        //Remove after tests
        data.ordersNumber = 0;
        
        base.Start();
    }

    protected override void AddTask() {
        if (_isTaskCreated) return;

        task = data.tasks[data.ordersNumber++];
        _isTaskCreated = true;

        InitializeTaskUI();
    }
    
    public ArticyObject GetDialogue() {
        return data.ordersNumber < data.dialogues.Capacity
            ? data.dialogues[data.ordersNumber].GetObject()
            : null;
    }

    public void Initialize() {
        GameObject art = Instantiate(data.art, gameObject.transform);
    }
}