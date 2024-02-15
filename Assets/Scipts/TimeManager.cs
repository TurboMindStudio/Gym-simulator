using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] timeText;

    private void Update()
    {
        for(int i = 0; i < timeText.Length; i++)
        {

            DateTime dateTime = DateTime.Now;
            string hour=LeadingZero(dateTime.Hour);
            string minute=LeadingZero(dateTime.Minute);
            string second=LeadingZero(dateTime.Second);
            timeText[i].text = hour + ":" + minute + ":" + second;
        
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }



    /*[Range(0,60)]
    [SerializeField] int hour;
    [Range(0,60)]
    [SerializeField] int minute;
    [Range (0,60)]
    [SerializeField] int seconds;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float currentTime;
    private int timerDefault;


    private void Start()
    {
        timerDefault = 0;
        timerDefault+= (seconds + (minute * 60) + (hour * 60 * 60));
        currentTime = timerDefault;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        timeText.text=TimeSpan.FromSeconds(currentTime).ToString(@"hh\:mm\:ss");
    }*/
}
