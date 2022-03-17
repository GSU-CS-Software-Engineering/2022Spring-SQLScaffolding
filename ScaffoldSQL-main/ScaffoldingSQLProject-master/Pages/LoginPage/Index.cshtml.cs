using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ScaffoldingSQLProject.Pages.LoginPage
{
    public class LoginPage : PageModel
    {

        public int UserID { get; set; }
        [Required]
        [BindProperty]
        public string Username { get; set; }

        [Required]
        [BindProperty, DataType(DataType.Password)]
        public string password { get; set; }

      //  public IActionResult OnPost()
       // {

      //  }

      //  public static string Hash(string value)
     //   {
           // return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
     //   }
  //

    }

  
}
