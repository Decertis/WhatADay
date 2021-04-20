using System;
namespace WhatADayVS
{
    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Time StartsAt { get; set; }
        public Time EndsAt { get; set; }
        public DateTime Date { get; set; }

        public Task(string Title, string Description,Time StartsAt,Time EndsAt,DateTime Date)
        {
            this.Title = Title;
            this.Description = Description;
            this.StartsAt = StartsAt;
            this.EndsAt = EndsAt;
            this.Date = Date;
        }
        public override string ToString()
        {
            return new string($"{Title} || {Description} || {StartsAt} - {EndsAt}");
        }
    }
}
