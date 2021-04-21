using System;
namespace WhatADayVS
{
    class Controller
    {
        private static string[] commands_array = { "select year", "select", "add", "delete", "next", "previous", "exit", "change saves path", "change color" };
        private bool IsCommandExist(string command)
        {
            foreach (string c in commands_array)
            {
                if (command.ToLower() == c)
                    return true;
            }
            return false;
        }
        public static void AddTask()
        {
            try
            {
                string temp;
                Console.Write("Title : ");
                string title = Console.ReadLine();
                Console.Write("Description : ");
                string description = Console.ReadLine();
                Console.Write("Beginning time in format h:m : ");
                temp = Console.ReadLine();
                string[] prase = temp.Split(':');
                int h = Convert.ToInt32(prase[0]);
                int m = Convert.ToInt32(prase[1]);
                Time StartsAt = new Time(h, m);
                Console.Write("Ending time in format h:m : ");
                temp = Console.ReadLine();
                prase = temp.Split(':');
                h = Convert.ToInt32(prase[0]);
                m = Convert.ToInt32(prase[1]);
                Time EndsAt = new Time(h, m);

                Console.Write("Write date in format day:month:year : ");
                temp = Console.ReadLine();
                prase = temp.Split(':');
                int _day = Convert.ToInt32(prase[0]);
                int _month = Convert.ToInt32(prase[1]);
                int _year = Convert.ToInt32(prase[2]);
                Task task = new Task(title, description, StartsAt, EndsAt, new DateTime(_year, _month, _day));
                Model.Events.Add(task);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AddTask();
            }
        }
        private static void Next()
        {
            if (Model.CurrentMonth + 1 < 12)
                Model.MonthToConsole(Model.CurrentMonth + 1);
        }
        private static void Previous()
        {
            if (Model.CurrentMonth - 1 > 0)
                Model.MonthToConsole(Model.CurrentMonth - 1);
        }
        public static void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "next":
                    Next();
                    break;
                case "previous":
                    Previous();
                    break;
                case "select year":
                    Console.Write("Write year : ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    if (year >= 0 && year < 2201)
                    {
                        Model.SelectYear(year);
                    }
                    else
                        throw new AggregateException("Wrong year!");
                    Model.MonthToConsole(Model.CurrentMonth);
                    break;
                case "select":
                    Console.Write("Write month : ");
                    int month = Convert.ToInt32(Console.ReadLine());
                    if (month > 0 && month < 13)
                        Model.MonthToConsole(month-1);
                    else
                        throw new AggregateException("Wrong month!");
                    break;
                case "add":
                    AddTask();
                    break;
            }
        }
    }
}
