using System;
namespace WhatADayVS
{
    class Program
    {
        static void Main(string[] args)
        {
            DataController.Load();
            Model.SelectYear(2021);
            Model.LoadTasks();
            foreach (Day day in Model.current_year[DateTime.Now.Month - 1])
            {
                Console.WriteLine($"{day.Date.ToShortDateString()} {day.DayOfWeek}");
                if (day.Event != null)
                    Console.WriteLine($"{day.Event}");
            }
            DataController.Save();
        }
    }
}
