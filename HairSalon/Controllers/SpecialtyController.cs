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
    }
}