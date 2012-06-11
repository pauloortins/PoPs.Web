using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoPs.Web.Validations;
using FluentValidation.Attributes;

namespace PoPs.Web.Models
{
    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordRepeated { get; set; }
        public string Email { get; set; }
    }
}