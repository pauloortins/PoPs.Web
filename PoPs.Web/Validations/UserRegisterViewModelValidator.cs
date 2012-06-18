using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using PoPs.Web.Models;

namespace PoPs.Web.Validations
{
    public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
    {
        public UserRegisterViewModelValidator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("'Login' deve ser preenchido.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("'Email' deve ser preenchido.")
                .EmailAddress().WithMessage("'Email' deve ser um endereço de email válido.");
            

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("'Senha' deve ser preenchido.")
                .Equal(x => x.PasswordRepeated).WithMessage("As senhas informadas devem ser iguais.");

            RuleFor(x => x.PasswordRepeated)
                .NotEmpty().WithMessage("'Repetir Senha' deve ser preenchido.")
                .Equal(x => x.Password).WithMessage("As senhas informadas devem ser iguais.");
        }
    }
}