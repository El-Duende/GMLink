﻿using System.ComponentModel.DataAnnotations;

namespace GMLink.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter a username.")]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}