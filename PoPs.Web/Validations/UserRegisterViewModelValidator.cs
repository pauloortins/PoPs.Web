using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using PoPs.Web.Models;
using PoPs.Service;

namespace PoPs.Web.Validations
{
    public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        private IUserService userService;

        public UserRegisterViewModelValidator(IUserService userService)
        {
            this.userService = userService;

            RuleFor(x => x.Login).NotEmpty().WithMessage("'Login' deve ser preenchido.");
            RuleFor(x => x.Login).Must(BeUniqueLogin).When(x => !string.IsNullOrEmpty(x.Login)).WithMessage("'Login' já existente.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("'Email' deve ser preenchido.")
                .EmailAddress().WithMessage("'Email' deve ser um endereço de email válido.");
            RuleFor(x => x.Email).Must(BeUniqueEmail).When(x => !string.IsNullOrEmpty(x.Email)).WithMessage("'Email' já existente.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("'Senha' deve ser preenchido.")
                .Equal(x => x.PasswordRepeated).WithMessage("As senhas informadas devem ser iguais.");

            RuleFor(x => x.PasswordRepeated)
                .NotEmpty().WithMessage("'Repetir Senha' deve ser preenchido.")
                .Equal(x => x.Password).WithMessage("As senhas informadas devem ser iguais.");
        }

        private bool BeUniqueLogin(string login)
        {
            return userService.FindByLogin(login) == null;
        }

        private bool BeUniqueEmail(string email)
        {
            return userService.FindByEmail(email) == null;
        }
    }
}