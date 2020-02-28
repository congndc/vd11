using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace vd11.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autheautherize(vd11.Models.User userModel)
        {
            using (LoginController login = new LoginController())
            {

            }
            return View();
        }
    }
}