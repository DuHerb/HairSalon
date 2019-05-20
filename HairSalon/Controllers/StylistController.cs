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
            Dictionary<string, object> model = new Dictionary<string, object>{};
            model.Add("clients", Client.GetAllByStylist(id));
            model.Add("stylist", Stylist.GetStylist(id));
            model.Add("specialties", Specialty.GetAllByStylist(id));
            model.Add("allSpecialties", Specialty.GetAll());
            return View(model);
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

        public IActionResult UpdateSpecialty(int specialtyId, int stylistId)
        {
            Specialty.AddStylist(stylistId, specialtyId);
            return RedirectToAction ("Show", new {id = stylistId});
        }

        public IActionResult Destroy(int stylistId)
        {
            Stylist.GetStylist(stylistId).DeleteStylist();
            return RedirectToAction("Index");
        }
    }
}