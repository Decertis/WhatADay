using System;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace WhatADayVS
{
    class Program
    {
        static void Main(string[] args)
        {
            Task Event = new Task("Crossing","Just run",new Time(12,30),new Time(13,10),new DateTime(DateTime.Now.Year, DateTime.Now.Month,21));
            List<Task> events = new List<Task>();
            events.Add(Event);
            Day[] month = new Day[DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month)];
            for(int i = 0; i < month.Length; i++)
            {
                month[i] = new Day { Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i + 1) };
                foreach (Task mark in events)
                {
                    if(mark.Date == month[i].Date)
                        month[i].Event = mark;           
                }
            }
            foreach(Day day in month)
            {
                Console.WriteLine($"{day.Date.ToShortDateString()} {day.DayOfWeek}");
                if(day.Event != null)
                    Console.WriteLine($"{ day.Event}");
            }
        }
    }
}
