using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalWPF.Models;
using FluentValidation;

namespace CarRentalWPF.Validators
{
    public class LoginFormValidator : AbstractValidator<LoginModel>
    {
        public LoginFormValidator()
        {
            RuleFor(x => x.Login)
                .MinimumLength(5)
                .MaximumLength(50)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .MinimumLength(5)
                .MaximumLength(50)
                .NotEmpty()
                .NotNull();
        }
    }
}
