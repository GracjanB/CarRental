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
        private SimpleContainer _container { get; set; }

        private IWindowManager _windowManager { get; set; }

        public MainViewModel(SimpleContainer simpleContainer, IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _container = simpleContainer;
            _windowManager = windowManager;
            eventAggregator.Subscribe(this);
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
            ActivateItem(_container.GetInstance<CarsViewModel>());
        }

        public void MainView_MouseLeftButtonDown()
        {
            ActivateItem(_container.GetInstance<RentCarFormViewModel>());
        }

        public void AgencyManageWindowShow()
        {
            var agencyManageVM = _container.GetInstance<AgencyManageViewModel>();
            _windowManager.ShowDialog(agencyManageVM);
        }

        public void LoginButtonPopupBoxClick()
        {
            LoginViewModel loginVM = _container.GetInstance<LoginViewModel>();
            _windowManager.ShowDialog(loginVM);
        }

        public void RegisterButtonPopupBoxClick()
        {
            RegisterViewModel registerVM = _container.GetInstance<RegisterViewModel>();
            _windowManager.ShowDialog(registerVM);
        }

        public void GetAccountInfo()
        {
            var user = (AuthenticatedUser)_container.GetInstance(typeof(IAuthenticatedUser), "AuthenticatedUser");
            Console.WriteLine();
        }

        public void Handle(UserLoggedInEvent userLoggedIn)
        {
            LoggedInUser = (LoggedInUserModel)_container.GetInstance(typeof(ILoggedInUserModel), "LoggedInUserModel");
        }
    }
}
