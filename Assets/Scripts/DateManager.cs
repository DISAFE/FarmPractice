using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public enum Season
{
    Spring,
    Summer,
    Fall,
    Winter,
}

public class DateManager : MonoBehaviour
{
    public static DateManager Main;
    public UnityEvent SeasonChange;
    public UnityEvent YearChange;
    public Season season;
    public int year;
    public int date;

    private int dateTime = 5;

    

    private void Awake()
    {
        Main = this;
        year = 1;
        date = 0;
        season = Season.Spring;
        YearChange = new ();
        SeasonChange = new();
    }

    private void Start()
    {
        StartCoroutine(DayCounter());
        Debug.Log("Year: " + year + " Date: " + date + " Season: " + season);
    }

    IEnumerator DayCounter()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(dateTime);
            date += 1;
            if(date >= 16) // year 증가
            {
                date = 1;
                year += 1;
                YearChange.Invoke();
            }
            if (season != (Season)(date / 4)) // 현재 season이 date기반 season과 다르다면
            {
                season = (Season)(date / 4);
                SeasonChange.Invoke();
            }
            Debug.Log("Year: " + year + " Date: " + date + " Season: " + season);
        }
    }
}

