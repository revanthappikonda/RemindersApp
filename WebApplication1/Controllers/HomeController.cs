using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private List<Reminder> _reminders;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _reminders = new List<Reminder>
            {
                new Reminder{ Name = "First", IsCompleted = true },
                new Reminder{ Name = "Second", IsCompleted = false },
                new Reminder{ Name = "Third", IsCompleted = true }
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Reminder()
        {
            return View(new ReminderViewModel(_reminders));
        }

        [HttpPost]
        public IActionResult AddReminder(IFormCollection form)
        {
            _reminders.Add(new Reminder { Name = form.First().Value, IsCompleted = false });
            return View(new ReminderViewModel(_reminders));
        }

        

        [HttpPost]
        public IActionResult DeleteReminder(IFormCollection form)
        {
            _reminders.RemoveAll(x => x.Name == form.ElementAt(1).Value);
            return View(new ReminderViewModel(_reminders));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
