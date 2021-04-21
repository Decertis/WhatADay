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
            Model.MonthToConsole(DateTime.Now.Month-1);
            while (true)
            {
                Controller.ExecuteCommand(Console.ReadLine());
                DataController.Save();
            }
        }
    }
}
