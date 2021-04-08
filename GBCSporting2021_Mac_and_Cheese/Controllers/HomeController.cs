using GBCSporting2021_Mac_and_Cheese.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Controllers
{
    public class HomeController : Controller
    {
        private SportContext context { get; set; }

        public HomeController(SportContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Current = "Home";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Current = "About";
            return View();
        }

    }
    
}
