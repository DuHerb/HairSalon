using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        public IActionResult Index()
        {
            List<Stylist> stylists = Stylist.GetAll();
            return View(stylists);
        }

        public IActionResult Create(string firstName, string lastName)
        {
            int id = Stylist.CreateStylist(firstName, lastName);
            return RedirectToAction("Show", new {id=id});
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpGet("/stylist/show/{id}")]
        public IActionResult Show(int id)
        {
            return View(Stylist.GetStylist(id));
        }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}