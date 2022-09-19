using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCustomer : Customer
{
    public SpecialCustomerData data;

    private void Start()
    {
        taskadd += CreateTask;
    }

    public void CreateTask()
    {
        task = data.tasks[data.currentTask];
        data.currentTask++;
    }

    public void Initialize()
    {
        GameObject art = Instantiate(data.Art, gameObject.transform);
    }
}

