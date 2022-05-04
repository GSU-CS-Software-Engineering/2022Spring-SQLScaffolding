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
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace ScaffoldingSQLProject.Pages.LoginPage
{
    public class LoginPage : PageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserID { get; set; }

        [Required]
        [BindProperty]
        [BsonElement("userName")]
        public string Username { get; set; } = null;

        [Required]
        [BindProperty, DataType(DataType.Password)]
        [BsonElement("password")]
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
        
       
    }
}
