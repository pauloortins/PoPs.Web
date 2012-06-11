using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using PoPs.Web.Models;

namespace PoPs.Web.Validations
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PasswordRepeated).NotEmpty();
        }
    }
}