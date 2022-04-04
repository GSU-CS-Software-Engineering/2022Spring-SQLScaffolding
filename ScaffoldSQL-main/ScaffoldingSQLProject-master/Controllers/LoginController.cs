using Microsoft.AspNetCore.Mvc;
using ScaffoldingSQLProject.Pages.LoginPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ScaffoldingSQLProject.Controllers
{
    public class LoginController : Controller
    {
        
        const string Connection = "mongodb+srv://<username>:<password>@sqlscaffolding.cyoep.mongodb.net/test";
        
        public LoginController()
        {

        }
         public ActionResult Index()
        {
     
            return View();
        }
    }
    //[HttpPost]
   
   
}
