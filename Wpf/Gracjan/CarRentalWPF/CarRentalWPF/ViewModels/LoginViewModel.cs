using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalWPF.Validators;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class LoginViewModel : Screen
    {
        public LoginModel loginModel { get; set; }

        private LoginFormValidator _loginValidator { get; set; }

        public LoginViewModel()
        {
            loginModel = new LoginModel();
            _loginValidator = new LoginFormValidator();
        }

        public void LoginButton()
        {
            var result = _loginValidator.Validate(loginModel);

            if (result.IsValid)
            {
                // TODO: Login user

                MessageBox.Show("Login good.");
            }
            else
            {
                string resultString = "";

                foreach (var failure in result.Errors)
                    resultString += "Property: " + failure.PropertyName + " - Error: " + failure.ErrorMessage + "\n";

                MessageBox.Show(resultString);
            }
                
        }
    }
}
