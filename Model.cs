using System;
using System.Collections.Generic;
namespace WhatADayVS
{
    class Model
    {
        public static List<Task> Events = new List<Task>();
        public static Day[][] current_year = new Day[12][];
        public static Day[][] SelectYear(int year_number)
        {

            for (int i = 0; i < current_year.Length; i++)
            {
                int month_number = i + 1;
                Day[] month = new Day[DateTime.DaysInMonth(year_number, month_number)];
                for (int k = 0; k < DateTime.DaysInMonth(year_number, i + 1); k++)
                {
                    month[k] = new Day() { Date = new DateTime(year_number, month_number, k + 1) };
                }
                current_year[i] = month;
            }
            return current_year;
        }
        public static void MonthToConsole(int number)
        {
            foreach (Day day in Model.current_year[number])
            {
                Console.WriteLine($"{day.Date.ToShortDateString()} {day.DayOfWeek}");
                if (day.Event != null)
                    Console.WriteLine($"{day.Event}");
            }
        }
        public static void LoadTasks()
        {
            foreach(Day[] month in current_year)
            {
                for(int i = 0; i < month.Length; i++)
                {
                    foreach(Task task in Events)
                    {
                        if(month[i].Date == task.Date)
                        {
                            month[i].Event = task;
                        }
                    }
                }
            }
        }
    }
}
