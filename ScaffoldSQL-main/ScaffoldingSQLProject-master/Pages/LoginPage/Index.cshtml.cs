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
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(12)]
        public string password { get; set; }

        public string PasswordEncryption(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
     

    }

  
}
