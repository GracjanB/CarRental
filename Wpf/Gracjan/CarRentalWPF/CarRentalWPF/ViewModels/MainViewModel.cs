using Caliburn.Micro;
using CarRentalWPF.Events;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<UserLoggedInEvent>
    {
        private SimpleContainer _simpleContainer { get; set; }

        private IWindowManager _windowManager { get; set; }

        public MainViewModel(SimpleContainer simpleContainer, IWindowManager windowManager)
        {
            _simpleContainer = simpleContainer;
            _windowManager = windowManager;
        }

        private LoggedInUserModel _loggedInUser;

        public LoggedInUserModel LoggedInUser
        {
            get { return _loggedInUser; }
            set 
            { 
                _loggedInUser = value;
                NotifyOfPropertyChange(() => LoggedInUser);
            }
        }



        public void Cars_MouseLeftButtonDown()
        {
            ActivateItem(_simpleContainer.GetInstance<CarsViewModel>());
        }

        public void MainView_MouseLeftButtonDown()
        {
            ActivateItem(_simpleContainer.GetInstance<RentCarFormViewModel>());
        }

        public void LoginButtonPopupBoxClick()
        {
            LoginViewModel loginVM = _simpleContainer.GetInstance<LoginViewModel>();
            _windowManager.ShowDialog(loginVM);
        }

        public void RegisterButtonPopupBoxClick()
        {
            RegisterViewModel registerVM = _simpleContainer.GetInstance<RegisterViewModel>();
            _windowManager.ShowDialog(registerVM);
        }

        public void GetAccountInfo()
        {
            var user = (AuthenticatedUser)_simpleContainer.GetInstance(typeof(IAuthenticatedUser), "AuthenticatedUser");
            Console.WriteLine();
        }

        public void Handle(UserLoggedInEvent userLoggedIn)
        {
            LoggedInUser = (LoggedInUserModel)_simpleContainer.GetInstance(typeof(ILoggedInUserModel), "LoggedInUserModel");
        }
    }
}
