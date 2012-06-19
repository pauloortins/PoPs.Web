using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoPs.Web.Validations;
using FluentValidation.Attributes;

namespace PoPs.Web.Models
{
    [Validator(typeof(UserForgotPasswordViewModelValidator))]
    public class UserForgotPasswordViewModel
    {
        public string Email { get; set; }
    }
}