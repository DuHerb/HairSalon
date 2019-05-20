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
            if(client.StylistId != 0)
            {
                ViewBag.Stylist = Stylist.GetStylist(client.StylistId);
            }
            else
            {
                ViewBag.AllStylists = Stylist.GetAll();
            }
            return View(client);
        }

        public IActionResult Destroy(int clientId)
        {
            Client.GetClient(clientId).DeleteClient();
            return RedirectToAction("Index");
        }

        public IActionResult DestroyAll()
        {
            Client.ClearAllClients();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateStylist(int stylistId, int clientId)
        {
            Client.GetClient(clientId).UpdateStylistId(stylistId);
            return RedirectToAction("Show", new {clientId = clientId});
        }

        [HttpGet("/client/show/{id}/edit")]
        public IActionResult Edit(int id)
        {
            Client client = Client.GetClient(id);
            return View(client);
        }

        public IActionResult Update(string firstName, string lastName, string phone, int clientId)
        {
            Client.GetClient(clientId).EditClientInfo(firstName, lastName, phone);
            return RedirectToAction("Show", new{clientId = clientId});
        }
    }
}