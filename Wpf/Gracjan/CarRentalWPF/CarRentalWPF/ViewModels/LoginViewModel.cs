using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using CarRentalWPF.Validators;
using System.Windows;
using CarRentalWPF.User;
using CarRentalWPF.Events;
using CarRentalWPF.Library2.ApiClient;
using AutoMapper;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.FromServerDto;

namespace CarRentalWPF.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IEventAggregator _events;

        private readonly IAuthenticationService _authService;

        private readonly IMapper _mapper;

        private readonly IUserClient _userClient;

        public LoginModel loginModel { get; set; }

        private LoginFormValidator _loginValidator { get; set; }


        public LoginViewModel(SimpleContainer simpleContainer, IEventAggregator eventAggregator,
            IAuthenticationService authService, IMapper mapper, IUserClient userClient)
        {
            loginModel = new LoginModel();
            _container = simpleContainer;
            _events = eventAggregator;

            _authService = authService;
            _mapper = mapper;
            _userClient = userClient;
        }

        public async void LoginButton()
        {
            // For testing
            loginModel.Login = "pawel121111@gmail.com";
            loginModel.Password = "Zaq12345@!";

            _loginValidator = new LoginFormValidator();
            var result = _loginValidator.Validate(loginModel);

            if (result.IsValid)
            {
                var userLoginDto = new UserLoginDto
                {
                    username = loginModel.Login,
                    password = loginModel.Password
                };

                TokenInfoDto token = null;

                try
                {
                    token = await _authService.GetTokenAsync(userLoginDto);
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                var authenticatedUser = _container.GetInstance<IAuthenticatedUser>();
                var loggedInUser = _container.GetInstance<ILoggedInUserModel>();
                var userData = await _userClient.GetUserDataAsync(token.token_type, token.access_token);

                authenticatedUser.Login(token.access_token, token.token_type, token.refresh_token, token.expires_in,
                    userData.user.agencyId, userData.user.id);
                loggedInUser.SetUserData2(userData);

                _events.PublishOnUIThread(new UserLoggedInEvent());
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
