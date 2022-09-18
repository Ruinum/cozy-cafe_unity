using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockUI : MonoBehaviour
{
    public const float IRL_secs_per_ingame_day = 300f; //1 день в игре = 5 минут

    public Transform clockHourHandTransform;
    public Transform clockMinHandTransform;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI CurrentDayText;
    public TextMeshProUGUI MonthText;

    public float day;
    public int theCurrentDay;
    public bool end_of_day;



    public void Awake()
    {
        clockHourHandTransform = transform.Find("Hour_hand");
        clockMinHandTransform = transform.Find("Min_hand");
        end_of_day = false;
        theCurrentDay = 1;

    }

    public void Update()
    {
        if (end_of_day != true)
        {
            day += Time.deltaTime / IRL_secs_per_ingame_day;

            float dayNormalized = day % 1f;


            float rotationDegreesPerDay = 720f;
            clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay + 90f);


            float hoursPerDay = 24f;
            clockMinHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

            string hoursString = Mathf.Floor((dayNormalized * 24f + 9f)).ToString("00");
            if (hoursString != "18")
            {
                string minString = Mathf.Floor(((dayNormalized * 24f) % 1f) * 60f).ToString("00");
                string TextString = hoursString + ":" + minString;
                timeText.text = TextString;
            }
            else
            {
                timeText.text = "18:00";
                end_of_day = true;
            }
            
        }
        else
        {
            theCurrentDay += 1; //Обновление дня
            end_of_day = false;
            day = 0;
            CurrentDayText.text = theCurrentDay.ToString();
            string[] weekdays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            MonthText.text = weekdays[(theCurrentDay - 1) % 7];
        }

    }
}
