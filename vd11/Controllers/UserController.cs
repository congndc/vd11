using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vd11.Models;

namespace vd11.Controllers
{
    public class UserController : Controller
    {
        public IActionResult AddOrEdit(int ID=0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            using (DbModel)
        }
    }
}