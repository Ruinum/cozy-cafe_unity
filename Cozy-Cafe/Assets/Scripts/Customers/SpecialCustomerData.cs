using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Customers/SpecialCustomerData")]
public class SpecialCustomerData : ScriptableObject
{
    public GameObject Art;
    public int currentTask;
    public List<Task> tasks = new List<Task>();
}
