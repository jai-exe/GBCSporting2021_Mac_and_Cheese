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
        private ContactContext context { get; set; }

        public CustomerController(ContactContext ctx)
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
            var customers = context.Customers
                               .Include(c => c.Country)
                               .FirstOrDefault(c => c.CustId == id);

            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(c => c.CountryName).ToList();
            return View(customers);
        }
        [HttpPost]
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
                return View(customer);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customers = context.Customers
                               .Include(c => c.Country)
                               .FirstOrDefault(c => c.CustId == id);
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
