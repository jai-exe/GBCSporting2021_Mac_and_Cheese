using GBCSporting2021_Mac_and_Cheese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Controllers
{
    public class CustomerController : Controller
    {
        private SportContext context { get; set; }

        public CustomerController(SportContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult List()
        {
            var customers = context.Customers
                               .Include(c => c.Country)
                               .OrderBy(c => c.CustFName).ToList();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            var customers = context.Customers.Find(id);
            return View(customers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.CustId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if(action == "Add")
                {
                    context.Customers.Add(customer);
                }
                else
                {
                    context.Customers.Update(customer);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Customer");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
                return View("Edit");
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customers = context.Customers.Find(id);
            return View(customers);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            return RedirectToAction("List","Customer");
        }
    }
}
