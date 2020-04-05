using Caliburn.Micro;
using CarRentalWPF.Models;
using CarRentalWPF.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class RegisterViewModel : Screen
    {
        public RegisterModel registerModel { get; set; }

        private RegisterFormValidator _registerValidator { get; set; }

        public RegisterViewModel()
        {
            registerModel = new RegisterModel();
        }

        public void RegisterButton()
        {
            _registerValidator = new RegisterFormValidator();
            var result = _registerValidator.Validate(registerModel);
            string message = "";

            if (result.IsValid)
                message = "Everything is good.";
            else
                foreach (var failure in result.Errors)
                    message += "Property: " + failure.PropertyName + "Error: " + failure.ErrorMessage;

            MessageBox.Show(message);
        }
    }
}
