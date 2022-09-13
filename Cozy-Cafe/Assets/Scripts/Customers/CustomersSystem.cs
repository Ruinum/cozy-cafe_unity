using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;
using DG.Tweening;

public class CustomersSystem : MonoBehaviour
{
    public static CustomersSystem Singletone;

    public float MinTime;
    public float MaxTime;

    private int CustomersCount;
    private bool[] Place = new bool[3];

    private readonly Vector3 startPos = new Vector3(-5.5f, -2, 0);
    private readonly Vector3 startPos2 = new Vector3(-8f, -2, 0);

    private void Start()
    {
        StartCoroutine(Generetor());
    }

    public void CreateNewCustomer()
    {
        GameObject _customer = Instantiate(Resources.Load<GameObject>("Prefabs/CustomerTest"),null);
        int CPos = 1;
        for (int i = 0; i < 3; i++)
        {
            if (!Place[i])
            {
                CPos = i;Place[i] = true;break;
            }
        }
        //_customer.transform.position = startPos + ((transform.right * 5.5f) * CPos);
        _customer.transform.position = startPos2;
        _customer.GetComponent<Customer>()._Pos = CPos;
        CustomersCount++;
        ComeAnimation2(_customer, startPos + ((transform.right * 5.5f) * CPos));
    }

   /*public void ComeAnimation(GameObject @object,Vector3 _startPos)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(@object.transform.DOMove(_startPos + @object.transform.up * 1, 0.5f));
        mySequence.Append(@object.transform.DOMove(_startPos + @object.transform.up * 0.1f, 0.1f));
        mySequence.Append(@object.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.05f));
        mySequence.Append(@object.transform.DOScale(new Vector3(1f, 1f, 1f), 0.05f));
        mySequence.Append(@object.transform.DOMove(_startPos + @object.transform.up * -0.1f, 0.1f));
    }*/
    public void ComeAnimation2(GameObject @object, Vector3 _Pos)
    {
        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(@object.transform.DOMove(_Pos,1));
        mySequence.Append(@object.transform.DOPunchScale(new Vector3(.2f, .2f, .2f), 0.25f));
        //mySequence.Append(@object.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.05f));
        //mySequence.Append(@object.transform.DOScale(new Vector3(1f, 1f, 1f), 0.05f));
        
    }

    public void CustomerLeave(GameObject customer)
    {
        CustomersCount--;
        Place[customer.GetComponent<Customer>()._Pos] = false;
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

