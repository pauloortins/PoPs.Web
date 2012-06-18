using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PoPs.Web.Validations;
using FluentValidation.Attributes;

namespace PoPs.Web.Models
{
    [Validator(typeof(UserLoginViewModelValidator))]
    public class UserLoginViewModel
    {
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}