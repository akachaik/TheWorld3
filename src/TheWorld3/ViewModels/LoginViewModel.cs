using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorld3.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
