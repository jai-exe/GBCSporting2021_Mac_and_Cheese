using GBCSporting2021_Mac_and_Cheese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Controllers
{
    public class TechnicianController : Controller
    {
        private SportContext context { get; set; }

        public TechnicianController(SportContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult List()
        {
            ViewBag.Current = "Technician";
            var technicians = context.Technicians
                               .OrderBy(c => c.TechName).ToList();
            return View(technicians);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Current = "Technician";
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Current = "Technician";
            var technicians = context.Technicians.Find(id);
            ViewBag.Action = "Edit";
            return View(technicians);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Technician tech)
        {
            ViewBag.Current = "Technician";
            string action = (tech.TechId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Technicians.Add(tech);
                }
                else
                {
                    context.Technicians.Update(tech);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = action;
                return View(tech);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Current = "Technician";
            var tech = context.Technicians.Find(id);
            return View(tech);
        }
        [HttpPost]
        public IActionResult Delete(Technician tech)
        {
            ViewBag.Current = "Technician";
            context.Technicians.Remove(tech);
            context.SaveChanges();
            return RedirectToAction("List", "Technician");
        }
    }
}
