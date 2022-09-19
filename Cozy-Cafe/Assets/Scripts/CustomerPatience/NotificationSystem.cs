using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;
using TMPro;

public class NotificationSystem : BaseSingleton<NotificationSystem>
{
    [SerializeField] private TextMeshProUGUI notificationText;

    private void Start() 
    { 
        notificationText.text = "";
    }

    public void Notify(string text)
    {
        notificationText.text = text;
        StartCoroutine(ShowNotification());
    }

    public IEnumerator ShowNotification()
    {
        yield return new WaitForSeconds(3);
        notificationText.text = "";
    }
}
