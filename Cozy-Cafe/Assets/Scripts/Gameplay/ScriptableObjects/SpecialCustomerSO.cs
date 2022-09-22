using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Customers/SpecialCustomerData")]
public class SpecialCustomerSO : ScriptableObject {
    public GameObject art;
    public List<Task> tasks;
    public List<ArticyRef> dialogues;
    [HideInInspector] public int ordersNumber;
}