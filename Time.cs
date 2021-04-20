using System;
namespace WhatADayVS
{
    class Time
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public Time(int hour,int minute)
        {
            if (minute <= 59 && minute >= 0)
            {
                Minute = minute;
            }
            if (hour <= 23 && hour >= 0)
            {
                Hour = hour;
            }
        }
        public Time(DateTime dateTime)
        {
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
        }
        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}",Hour,Minute);
        }
    }
}
