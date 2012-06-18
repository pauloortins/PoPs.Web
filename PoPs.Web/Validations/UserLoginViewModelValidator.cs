using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoPs.Web.Models;
using FluentValidation;

namespace PoPs.Web.Validations
{
    public class UserLoginViewModelValidator : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginViewModelValidator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("'Login' deve ser preenchido.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("'Senha' deve ser preenchido.");
        }
    }
}