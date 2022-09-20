using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;
using DG.Tweening;
using DialogueSystem;
using Ruinum.Utils;

public class CustomersSystem : BaseSingleton<CustomersSystem> {
    public float minTime;
    public float maxTime;

    public List<GameObject> TodaySpecialCustomers { get; set; }
    
    private Dictionary<DayType, List<GameObject>> allSpecialCustomers;
    private int customersCount;
    private bool[] Place = new bool[3];
    private float spawningProbability = 0.2f;

    private readonly Vector3 startPos = new Vector3(-5.5f, -2, 0);
    private readonly Vector3 startPos2 = new Vector3(-8f, -2, 0);

    private void Start() {
        InitializeSchedule();
        StartCoroutine(Generator());
    }

    private GameObject GetCustomer() {
        if (TodaySpecialCustomers == null || TodaySpecialCustomers.Capacity <= 0)
            return Resources.Load<GameObject>("Prefabs/CustomerTest");
        
        if (RandomExtentions.RandomLess(spawningProbability)) {
            GameObject customer = TodaySpecialCustomers[0];
            TodaySpecialCustomers.Remove(customer);

            if (spawningProbability > 0.4f) spawningProbability -= 0.4f;
                
            return customer;
        }

        spawningProbability += 0.1f;
        return Resources.Load<GameObject>("Prefabs/CustomerTest");

    }

    private void CreateNewCustomer() {
        GameObject customerGO = Instantiate(GetCustomer(), null);
        int cPos = 1;
        for (int i = 0; i < 3; i++) {
            if (!Place[i]) {
                cPos = i;
                Place[i] = true;
                break;
            }
        }

        customerGO.transform.position = startPos2;
        var customer = customerGO.GetComponent<Customer>();
        customer._Pos = cPos;

        if (customer is SpecialCustomer specialCustomer) {
            DialogueManager.Singleton.StartDialogue(specialCustomer.GetDialogue());
        }

        customersCount++;
        ComeAnimation2(customerGO, startPos + ((transform.right * 5.5f) * cPos));
    }

    private static void ComeAnimation2(GameObject @object, Vector3 _Pos) {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(@object.transform.DOMove(_Pos, 1));
        mySequence.Append(@object.transform.DOPunchScale(new Vector3(.2f, .2f, .2f), 0.25f));
    }

    public void CustomerLeave(GameObject customer) {
        customersCount--;
        Place[customer.GetComponent<Customer>()._Pos] = false;
        Destroy(customer);
    }

    private IEnumerator Generator() {
        for (;;) {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            if (customersCount < 3) CreateNewCustomer();
        }
    }

    private void InitializeSchedule() {
        //TODO: fill the list
        
        SubscribeSchedule();
    }

    private void SubscribeSchedule() {
        foreach (var (key, value) in allSpecialCustomers) {
            WeekSystem.Singleton.AddDayLogic(new CustomersSchedule() {Customers = value}, key);
        }
    }
}

public class CustomersSchedule : IDayLogic {
    public List<GameObject> Customers { get; set; }

    public void DayLogic() {
        CustomersSystem.Singleton.TodaySpecialCustomers = Customers;
    }
}