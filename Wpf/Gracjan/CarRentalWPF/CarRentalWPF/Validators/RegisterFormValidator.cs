using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using CarRentalWPF.Models;

namespace CarRentalWPF.Validators
{
    public class RegisterFormValidator : AbstractValidator<RegisterModel>
    {
        public RegisterFormValidator()
        {
            RuleFor(x => x.FirstName)
                .Length(3, 30)
                .NotEqual(x => x.LastName);

            RuleFor(x => x.LastName)
                .Length(3, 30)
                .NotEqual(x => x.FirstName);

            RuleFor(x => x.Password)
                .Length(5, 24);

            RuleFor(x => x.ConfirmPassword)
                .Length(5, 24)
                .Equal(x => x.Password);

            RuleFor(x => x.City)
                .Length(3, 50);

            RuleFor(x => x.Country)
                .Length(3, 50);

            RuleFor(x => x.Street)
                .Length(5, 50);

            RuleFor(x => x.HouseNo)
                .NotEmpty();

            RuleFor(x => x.FlatNo)
                .NotEmpty();

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .Length(6);

            RuleFor(x => x.PESEL)
                .NotEmpty()
                .Length(11);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Length(9);
        }
    }
}
