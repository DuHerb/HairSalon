using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        public IActionResult Index()
        {
            List<Specialty> specialties = Specialty.GetAll();
            return View(specialties);
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Create(string name)
        {
            Specialty.CreateSpecialty(name);
            return RedirectToAction("Index");
        }

        [HttpGet("/specialty/show/{id}")]
        public IActionResult Show(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>{};
            model.Add("specialty", Specialty.GetSpecialty(id));
            model.Add("selectedStylists", Stylist.GetAllBySpecialty(id));
            model.Add("allStylists", Stylist.GetAll());
            return View(model);
        }

        public IActionResult AddStylist(int specialtyId, int stylistId)
        {
            Specialty.AddStylist(stylistId, specialtyId);
            return RedirectToAction("Show", new{id = specialtyId});
        }
    }
}