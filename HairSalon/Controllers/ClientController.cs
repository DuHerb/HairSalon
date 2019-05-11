using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            List<Client> clients = Client.GetAll();
            return View(clients);
        }

        [HttpPost("/Client/New/{stylistId}")]
        public IActionResult Create(int stylistId, string firstName, string lastName)
        {
            // int stylistId = int.Parse(stylistId);
            int id = Client.CreateClient(stylistId, firstName, lastName);
            return RedirectToAction("Show", new {id=id});
        }

        // [HttpGet("/Client/New/{stylistId}")]
        public IActionResult New()
        {
            // string linkString = "<a class='nav-link text-dark new-stylist' asp-controller='Client' asp-action='New' asp-route-id = '" + stylistId + "'>Add New Customer</a>";
            // ViewBag.id = stylistId;

            return View();
        }

        [HttpGet("/client/show/{id}")]
        public IActionResult Show(int id)
        {
            return View(Client.GetClient(id));
        }
    }
}