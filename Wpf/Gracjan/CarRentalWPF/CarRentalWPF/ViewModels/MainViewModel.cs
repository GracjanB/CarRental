using Caliburn.Micro;
using CarRentalWPF.Events;
using CarRentalWPF.User;
using CarRentalWPF.ViewModels.Rentals;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<UserLoggedInEvent>
    {
        private readonly SimpleContainer _container;

        private readonly IWindowManager _windowManager;

        private readonly ILoggedInUserModel _user;

        public MainViewModel(SimpleContainer simpleContainer, IWindowManager windowManager, IEventAggregator eventAggregator, 
            ILoggedInUserModel loggedInUserModel)
        {
            _container = simpleContainer;
            _windowManager = windowManager;
            _user = loggedInUserModel;
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
            // FOR TESTING
            var finishRentVM = _container.GetInstance<FinishRentalViewModel>();
            ActivateItem(finishRentVM);
        }

        public void AgencyManageWindowShow()
        {
            if(!_user.isActive)
            {
                MessageBox.Show("ACCESS ERROR\nYou have to log in");
            }
            if(_user.Role == "MANAGER")
            {
                var agencyManageVM = _container.GetInstance<AgencyManageViewModel>();
                _windowManager.ShowDialog(agencyManageVM);
            }
            else
            {
                MessageBox.Show("You have no access to this element");
            }
        }

        public void RentalListViewShow()
        {
            var rentalsVM = _container.GetInstance<RentalsViewModel>();
            ActivateItem(rentalsVM);
        }

        public void RentalViewShow()
        {
            var rentCarFormVM = _container.GetInstance<RentCarFormViewModel>();
            ChangeActiveItem(rentCarFormVM, true);
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

        public void Handle(UserLoggedInEvent userLoggedIn)
        {
            LoggedInUser = (LoggedInUserModel)_container.GetInstance<ILoggedInUserModel>();
        }
    }
}
