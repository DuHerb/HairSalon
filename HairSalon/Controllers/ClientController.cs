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
            int clientId = Client.CreateClient(stylistId, firstName, lastName);
            return RedirectToAction("Show", new {clientId = clientId});
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpGet("/client/show/{clientId}")]
        public IActionResult Show(int clientId)
        {
            Client client = Client.GetClient(clientId);
            ViewBag.Stylist = Stylist.GetStylist(client.StylistId);
            return View(client);
        }
    }
}