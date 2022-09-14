using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;
using Ruinum.Core;
using UnityEngine.Events;

public class CustomersSystem : MonoBehaviour {
    public static CustomersSystem Singletone;

    public float MinTime;
    public float MaxTime;
    
    [SerializeField] private UnityEvent<ArticyObject> onCustomerArrived;

    private int CustomersCount;

    private void Start()
    {
        StartCoroutine(Generetor());
    }



    //Fix: Customer Pos

    public void CreateNewCustomer()
    {
        GameObject _customer = Instantiate(Resources.Load<GameObject>("Prefabs/CustomerArticyTest"),null);
        _customer.transform.position += (transform.right * 1.2f) * CustomersCount;
        onCustomerArrived.Invoke(_customer.GetComponent<ArticyReference>().reference.GetObject());
        CustomersCount++;
    }

    public void CustomerLeave(GameObject customer)
    {
        CustomersCount--;
        Destroy(customer);
    }

    private IEnumerator Generetor()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
            if (CustomersCount < 1) CreateNewCustomer();
        }
    }

    private void Awake()
    {
        Singletone = this;
    }
}

