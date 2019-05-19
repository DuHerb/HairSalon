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
            List<Client> clients = new List<Client>{};
            clients = Client.GetAllByStylist(id);
            ViewBag.Id = id;
            ViewBag.Clients = clients;
            return View(Stylist.GetStylist(id));
        }

        [HttpGet("/stylist/show/{id}/edit")]
        public IActionResult Edit(int id)
        {
            Stylist stylist = Stylist.GetStylist(id);
            return View(stylist);
        }

        public IActionResult Update(string firstName, string lastName, int id)
        {
            Stylist.GetStylist(id).EditName(firstName, lastName);
            return RedirectToAction("Show", new {id = id});
        }

        public IActionResult Destroy(int stylistId)
        {
            Stylist.GetStylist(stylistId).DeleteStylist();
            return RedirectToAction("Index");
        }
    }
}