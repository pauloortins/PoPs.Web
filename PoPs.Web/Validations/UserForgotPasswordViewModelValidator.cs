using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PoPs.Service;
using PoPs.Web.Models;
using FluentValidation;

namespace PoPs.Web.Validations
{
    public class UserForgotPasswordViewModelValidator : AbstractValidator<UserForgotPasswordViewModel>
    {
        private IUserService userService;

        public UserForgotPasswordViewModelValidator(IUserService userService)
        {
            this.userService = userService;

            RuleFor(x => x.Email).NotEmpty().WithMessage("'Email' deve ser preenchido.");
            RuleFor(x => x.Email).Must(Exists).Unless(x => string.IsNullOrEmpty(x.Email)).WithMessage("'Email' não cadastrado.");
        }

        public bool Exists(string email)
        {
            return userService.FindByEmail(email) != null;
        }
    }
}