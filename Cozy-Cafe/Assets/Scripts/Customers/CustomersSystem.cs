using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;
using Ruinum.Core;
using DG.Tweening;
using UnityEngine.Events;

public class CustomersSystem : MonoBehaviour
{
    public static CustomersSystem Singletone;

    public float MinTime;
    public float MaxTime;
    
    [SerializeField] private UnityEvent<ArticyObject> onCustomerArrived;

    private int CustomersCount;
    private bool[] Place = new bool[3];

    private readonly Vector3 startPos = new Vector3(-5.5f, -2, 0);
    private readonly Vector3 startPos2 = new Vector3(-8f, -2, 0);

    private bool _nextSpecialCustomer;
    private bool _haveSpecialCustomer;

    private void Start()
    {
        CreateSpecialCustomer();
        //StartCoroutine(Generetor());
    }

    public void CreateNewCustomer()
    {
        GameObject _customer = Instantiate(Resources.Load<GameObject>("Prefabs/CustomerArticyTest"),null);
        int CPos = 1;
        for (int i = 0; i < 3; i++)
        {
            if (!Place[i])
            {
                CPos = i;Place[i] = true;break;
            }
        }
        _customer.transform.position = startPos2;
        _customer.GetComponent<RandomCustomer>()._Pos = CPos;
        onCustomerArrived?.Invoke(_customer.GetComponent<RandomCustomer>().customerDialogue.GetDialogue());
        CustomersCount++;
        ComeAnimation(_customer, startPos + ((transform.right * 5.5f) * CPos));
    }

    public void CreateSpecialCustomer()
    {
        _nextSpecialCustomer = false;
        _haveSpecialCustomer = true;

        GameObject _customer = Instantiate(Resources.Load<GameObject>("Prefabs/SpecialCustomerTest"), null);
        _customer.GetComponent<SpecialCustomer>().Initialize();

        _customer.transform.position = startPos2;
        //onCustomerArrived?.Invoke(_customer.GetComponent<RandomCustomer>().customerDialogue.GetDialogue());
        CustomersCount++;
        ComeAnimation(_customer, startPos + ((transform.right * 5.5f)));
       
    }

    public void ComeAnimation(GameObject @object, Vector3 _Pos)
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(@object.transform.DOMove(_Pos,1));
        mySequence.Append(@object.transform.DOPunchScale(new Vector3(.2f, .2f, .2f), 0.25f));
    }

    public void CustomerLeave(GameObject customer)
    {
        CustomersCount--;
        Place[customer.GetComponent<RandomCustomer>()._Pos] = false;
        if (customer.GetComponent<SpecialCustomer>() && _haveSpecialCustomer) _haveSpecialCustomer = false;
        Destroy(customer);
    }

    private IEnumerator Generetor()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(Random.Range(MinTime, MaxTime));
            if (CustomersCount < 3 && (!_haveSpecialCustomer || !_nextSpecialCustomer)) CreateNewCustomer();
        }
    }

    private void Awake()
    {
        Singletone = this;
    }
}

