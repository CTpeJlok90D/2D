using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date
{
    public const int SecondsInMinut = 100;
    public const int MinutsInHour = 100;
    public const int HoursInDay = 25;
    public const int DaysInMonth = 25;

    private float _seconds;
    private int _minuts;
    private int _hours;
    private int _day;
    private Month _month;
    private int _year;

    public Date(int minuts = 0, int hours = 0, int day = 0, Month month = Month.Lightfall, int year = 0)
    {
        Minuts = minuts;
        Hour = hours;
        Day = day;
        Month = month;
        Year = year;
    }
    public static int MonthsInYear
    { 
        get 
        {
            return Enum.GetNames(typeof(Month)).Length;
        }
        private set{}
    }
    public float Seconds
    {
        get
        {
            return _seconds;
        }
        set
        {
            if (value / SecondsInMinut > 0)
            {
                Minuts += (int)(value / SecondsInMinut);
            }
            _seconds = value % SecondsInMinut;
        }
    }
    public int Minuts 
    {
        get
        {
            return _minuts;
        }
        set
        {
            if (value / MinutsInHour > 0)
            {
                Hour += value / MinutsInHour;
            }
            _minuts = value % MinutsInHour;
        }
    }
    public int Hour
    {
        get => _hours;
        set
        {
            if (value / HoursInDay > 0)
            {
                Day += value / HoursInDay;
            }
            _hours = value % HoursInDay;
        }
    }
    public int Day
    {
        get
        {
            return _day;
        }
        set
        {
            if (value / DaysInMonth > 0)
            {
                Month = (Month)((int)Month + 1);
            }
            _day = Mathf.Clamp(value % DaysInMonth, 1, DaysInMonth);
        }
    }
    public Month Month
    {
        get
        {
            return _month;
        }
        private set
        {
            if ((int)value > MonthsInYear)
            {
                _month = (Month)0;
                _year += 1;
                return;
            }
            _month = value;
        }
    }
    public int Year
    {
        get
        {
            return _year;
        }
        private set
        {
            _year = (int)Mathf.Clamp(value, 1, Mathf.Infinity);
        }
    }
}