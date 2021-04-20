using System;
namespace WhatADayVS
{
    class Day
    {
        public DateTime Date;
        public Task Event { get; set; }
        public string DayOfWeek 
        {
            get
            {
                return Date.DayOfWeek.ToString();
            }
        }
    }
}
