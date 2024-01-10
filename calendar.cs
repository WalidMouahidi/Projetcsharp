using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen
{
    class Schedule
    {
        public string EventName { get; set; }
        public DateTime Date { get; set; }

        public Schedule(string eventName, DateTime date)
        {
            EventName = eventName;
            Date = date;
        }
    }

    class Calendar
    {
        public static List<Schedule> Schedules { get; set; }

        public Calendar()
        {
            Schedules = new List<Schedule>();
        }

        public void AddSchedule(string eventName, DateTime date)
        {
            Schedules.Add(new Schedule(eventName, date));
            Console.WriteLine($"{eventName} scheduled for {date} added successfully.");
        }

       public static void DisplayWeeklySchedule()
{
    // Check if Schedules is null
    if (Schedules == null)
    {
        Console.WriteLine("No schedules available.");
        return;
    }

    // Assuming a week starts on Monday and ends on Sunday
    DateTime currentDate = DateTime.Now.Date;
    DateTime endOfWeekDate = currentDate.AddDays(6); // Display the schedule for the next 7 days

    Console.WriteLine($"Weekly Schedule:");

    while (currentDate <= endOfWeekDate)
    {
        Console.WriteLine($"=== {currentDate.ToString("dddd, MMMM dd")} ===");

        // Display events for the day
        var eventsForDay = Schedules.Where(s => s.Date.Date == currentDate.Date);
        if (eventsForDay.Any())
        {
            foreach (var schedule in eventsForDay)
            {
                Console.WriteLine($"- {schedule.EventName}");
            }
        }
        else
        {
            Console.WriteLine("No events scheduled for this day.");
        }

        Console.WriteLine(); // Empty line for better readability
        currentDate = currentDate.AddDays(1); // Move to the next day
    }
}

}
}