using Availibility.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Availibility.Data;
using Microsoft.EntityFrameworkCore;

namespace Availibility.Controllers
{
    public class HomeController : Controller
    {
        public AvailibilityContext _context;

        public HomeController(AvailibilityContext context)
        {
            _context = context;
        }
        public IActionResult Admin()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Total = 1;
            List<Appointment> t0 = new List<Appointment>();
            List<Appointment> t1 = new List<Appointment>();
            List<Appointment> t2 = new List<Appointment>();
            List<Appointment> t3 = new List<Appointment>();
            List<Appointment> t4 = new List<Appointment>();
            List<Appointment> t5 = new List<Appointment>();
            List<List<Appointment>> days = new List<List<Appointment>>() {t0, t1, t2, t3, t4, t5 };
            foreach (var i in _context.Appointment)
            {
                var delta = (i.Time.Date - DateTime.Now.Date).TotalDays;
                if (((int)delta < 0) || ((int)delta > 5)) {
                    continue;
                }
                days[(int)delta].Add(i);
            }
            ViewBag.Upcoming = days;
            //now need to sort each list so it displays properly.
            return View(await _context.Appointment.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Appointments()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
