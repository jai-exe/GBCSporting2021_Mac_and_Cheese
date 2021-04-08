using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_Mac_and_Cheese.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult GetCustomer()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}
