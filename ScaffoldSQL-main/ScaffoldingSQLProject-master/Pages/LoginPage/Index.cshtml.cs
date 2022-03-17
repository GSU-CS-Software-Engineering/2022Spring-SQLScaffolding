using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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

        public static string Encrypt(string value)
        {

            using (SHA256 hash = SHA256.Create())
            {
                byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }


        }

        /// <summary>
        /// make a text 
        /// </summary>
        /// <returns></returns>
        private List<LoginPage> GetUsers()
        {
            var usersList = new List<LoginPage>
            {
                new LoginPage
                {
                    UserID = 1,
                    Username = "Alexis",
                    password = "Admin"

                },
                new LoginPage
                {
                    UserID = 2,
                    Username = "Stephen",
                    password = "Admin"
                },
                new LoginPage
                {
                    UserID = 3,
                    Username = "Desmond",
                    password = "Admin"
                },
                new LoginPage
                {
                    UserID = 4,
                    Username = "Ricardo",
                    password = "Admin"
                }
            };
            return usersList;
        }

    }
}
