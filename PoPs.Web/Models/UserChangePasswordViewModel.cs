using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoPs.Web.Validations;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PoPs.Web.Models
{
    [Validator(typeof(UserChangePasswordViewModelValidator))]
    public class UserChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repetir Senha")]
        public string NewPasswordRepeated { get; set; }
    }
}