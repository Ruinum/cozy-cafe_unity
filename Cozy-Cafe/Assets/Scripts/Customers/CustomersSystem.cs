using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;

public class CustomersSystem : MonoBehaviour
{
    public static CustomersSystem Singletone;

    public float MinTime;
    public float MaxTime;

    private int CustomersCount;

    private void Start()
    {
        StartCoroutine(Generetor());
    }



    //Fix: Customer Pos

    public void CreateNewCustomer()
    {
        GameObject _customer = Instantiate(Resources.Load<GameObject>("Prefabs/CustomerTest"),null);
        _customer.transform.position += (transform.right * 1.2f) * CustomersCount;
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
            if (CustomersCount < 3) CreateNewCustomer();
        }
    }

    private void Awake()
    {
        Singletone = this;
    }
}

