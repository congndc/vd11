using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vd11.Models;
using vd11.Repository;

namespace vd11.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                


            }
            return View();
        }
    }
}