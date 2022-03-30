using Microsoft.AspNetCore.Mvc;
using ScaffoldingSQLProject.Pages.LoginPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScaffoldingSQLProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
   //[HttpPost]
   
}
