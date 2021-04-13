using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ReminderViewModel
    {
        public ReminderViewModel(List<Reminder> reminders)
        {
            Reminders = reminders;
        }

        public List<Reminder> Reminders { get; set; }

    }

    public class Reminder
    {
        public string Name { get; set; }

        public bool IsCompleted { get; set; }
    }
}
