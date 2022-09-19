using UnityEngine;
using Ruinum.Core;
using System.Collections;
using TMPro;

public class CustomerPatience : MonoBehaviour
{
    [SerializeField] private float waitingTime = 30;
    private int amount = 100;

    private void Start() => StartCoroutine(StartWaiting());

    private IEnumerator StartWaiting()
    {
        yield return new WaitForSeconds(waitingTime);
        
        NotificationSystem.Singleton.Notify("Вы слишком долго делаете заказ. Терпение клиента не вечно! Поторопитесь!");

        yield return new WaitForSeconds(waitingTime);

        NotificationSystem.Singleton.Notify("Клиента устал ждать! Он ушел...");
        MoneySystem.Singleton.SubtractAmount(amount);
    }
}
