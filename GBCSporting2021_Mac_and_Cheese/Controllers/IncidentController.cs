using GBCSporting2021_Mac_and_Cheese.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Controllers
{
    public class IncidentController : Controller
    {
        private SportContext context { get; set; }

        public IncidentController(SportContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult List()
        {
            var incidents = context.Incidents
                               .Include(c => c.Customer)
                               .Include(c => c.Product)
                               .Include(c => c.Technician)
                               .OrderBy(c => c.Title).ToList();
            return View(incidents);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = context.Customers.OrderBy(c => c.CustFName).ToList();
            ViewBag.Products = context.Products.OrderBy(c => c.ProductName).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(c => c.TechName).ToList();
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var incidents = context.Incidents.Find(id);
            ViewBag.Action = "Edit";
            ViewBag.Customers = context.Customers.OrderBy(c => c.CustFName).ToList();
            ViewBag.Products = context.Products.OrderBy(c => c.ProductName).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(c => c.TechName).ToList();
            return View(incidents);
        }
        [HttpGet]
        public IActionResult Edit(Incident incident)
        {
            string action = (incident.IncidentId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Customers = context.Customers.OrderBy(c => c.CustFName).ToList();
                ViewBag.Products = context.Products.OrderBy(c => c.ProductName).ToList();
                ViewBag.Technicians = context.Technicians.OrderBy(c => c.TechName).ToList();
                return View(incident);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incidents = context.Incidents.Find(id);
            return View(incidents);
        }
        [HttpGet]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", "Incident");
        }
    }
}
