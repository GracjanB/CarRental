using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalWPF.Validators;
using System.Windows;
using Newtonsoft.Json;
using CarRentalWPF.Library.ApiClient;
using CarRentalWPF.Library.Models;
using CarRentalWPF.User;
using CarRentalWPF.Events;

namespace CarRentalWPF.ViewModels
{
    public class LoginViewModel : Screen
    {
        public LoginModel loginModel { get; set; }

        private UserLogin userLogin { get; set; }

        private LoginFormValidator _loginValidator { get; set; }

        private UserLoginClient _userClient;

        private SimpleContainer _container;

        private IEventAggregator _events;


        public LoginViewModel(SimpleContainer simpleContainer, IEventAggregator eventAggregator)
        {
            loginModel = new LoginModel();
            _userClient = new UserLoginClient();
            _container = simpleContainer;
            _events = eventAggregator;
        }

        public async void LoginButton()
        {
            _loginValidator = new LoginFormValidator();
            var result = _loginValidator.Validate(loginModel);

            if (result.IsValid)
            {
                // TODO: Change this
                userLogin = new UserLogin()
                {
                    username = loginModel.Login,
                    password = loginModel.Password
                };

                var resultResponse = await _userClient.GetToken(userLogin);

                if (resultResponse.isSucceded)
                {
                    var userData = await _userClient.GetUserData(resultResponse.token_type, resultResponse.access_token);

                    var user = _container.GetInstance<IAuthenticatedUser>();
                    user.Login(resultResponse.access_token, resultResponse.token_type, resultResponse.refresh_token, resultResponse.expires_in);

                    // var loggedInUser = (LoggedInUserModel)_container.GetInstance(typeof(ILoggedInUserModel), "LoggedInUserModel");
                    var loggedInUser = _container.GetInstance<ILoggedInUserModel>();

                    if(userData.isSucceded)
                    {
                        loggedInUser.SetUserData(userData);
                    }

                    // This doesn't work
                    _events.PublishOnUIThread(new UserLoggedInEvent());     
                }

                this.TryClose();
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
