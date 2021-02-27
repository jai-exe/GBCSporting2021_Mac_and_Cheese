﻿using GBCSporting2021_Mac_and_Cheese.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Controllers
{
    public class ProductController : Controller
    {
        private SportContext context { get; set; }

        public ProductController(SportContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult List()
        {
            var products = context.Products
                               .OrderBy(c => c.ProductName).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var products = context.Products.Find(id);

            ViewBag.Action = "Edit";
            return View(products);
        }
        [HttpGet]
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = action;
                return View(product);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var products = context.Products.Find(id);
            return View(products);
        }
        [HttpGet]
        public IActionResult Delete(Product products)
        {
            context.Products.Remove(products);
            context.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
