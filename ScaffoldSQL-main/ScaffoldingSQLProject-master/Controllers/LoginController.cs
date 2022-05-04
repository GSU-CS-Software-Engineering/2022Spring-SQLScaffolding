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
        private IMongoCollection<LoginPage> collection;
        
        
        public LoginController()
        {
            var client =new MongoClient("mongodb+srv://<username>:<password>@sqlscaffolding.cyoep.mongodb.net/test");
            IMongoDatabase db = client.GetDatabase("SQLScaffolding");
            this.collection = db.GetCollection<LoginPage>("Login");
        }
         public ActionResult Index()
        {
            var model = collection.Find(FilterDefinition<LoginPage>.Empty).ToList();
            return View();
        }
    }
    //[HttpPost]
   
   
}
