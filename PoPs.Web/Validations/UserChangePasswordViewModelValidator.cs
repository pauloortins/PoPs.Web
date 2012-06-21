using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using PoPs.Web.Models;
using PoPs.Service;
using PoPs.Domain;
using PoPs.Infrasctructure;

namespace PoPs.Web.Validations
{
    public class UserChangePasswordViewModelValidator : AbstractValidator<UserChangePasswordViewModel>
    {
        private IUserService userService;
        private string userLogin;

        public UserChangePasswordViewModelValidator(IUserService userService, string userLogin)
        {
            this.userService = userService;
            this.userLogin = userLogin;

            RuleFor(x => x.OldPassword).NotEmpty().WithMessage("'Senha Atual' deve ser preenchido.");
            RuleFor(x => x.OldPassword).Must(BeEqualToUserPassword).When(x => !string.IsNullOrWhiteSpace(x.OldPassword)).WithMessage("'Senha Atual' inválida.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("'Senha' deve ser preenchido.")
                .Equal(x => x.NewPasswordRepeated).WithMessage("As senhas informadas devem ser iguais.");

            RuleFor(x => x.NewPasswordRepeated)
                .NotEmpty().WithMessage("'Repetir Senha' deve ser preenchido.")
                .Equal(x => x.NewPassword).WithMessage("As senhas informadas devem ser iguais.");
        }

        private bool BeEqualToUserPassword(string oldPassword)
        {
            User user = userService.FindByLogin(userLogin);

            if (PasswordHash.GetMD5Hash(oldPassword).Equals(user.Password))
            {
                return true;
            }

            return false;
        }
    }
}