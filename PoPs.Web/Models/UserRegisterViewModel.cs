using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoPs.Web.Validations;
using FluentValidation.Attributes;
using PoPs.Domain;
using PoPs.Infrasctructure;
using System.ComponentModel.DataAnnotations;

namespace PoPs.Web.Models
{
    [Validator(typeof(UserRegisterViewModelValidator))]
    public class UserRegisterViewModel
    {
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repetir Senha")]
        public string PasswordRepeated { get; set; }
        
        public string Email { get; set; }

        public User ConvertToDomain()
        {
            return new User()
            {
                Login = this.Login,
                Email = this.Email,
                Password = PasswordHash.GetMD5Hash(this.Password)
            };
        }
    }
}