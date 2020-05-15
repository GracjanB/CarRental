using Caliburn.Micro;
using CarRentalWPF.Converters;
using CarRentalWPF.Library.ApiClient.UserResource;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormUserChoiceViewModel : Screen
    {
        private SimpleContainer _container;

        private IUserClient _userClient;

        private IModelToRequestContentConverter _converter;

        
        public RentCarFormUserChoiceViewModel(SimpleContainer simpleContainer, IUserClient userClient, IModelToRequestContentConverter converter)
        {
            _container = simpleContainer;
            _userClient = userClient;
            _converter = converter;

            RegisterFormModel = new RegisterModel();
        }


        #region Car Card Info

        private CarModel _car;

        public CarModel Car
        {
            get { return _car; }
            set 
            { 
                _car = value;
                NotifyOfPropertyChange(() => Car);
            }
        }

        public void LoadCarModel(CarModel carModel)
        {
            // Change it to copy constructor
            Car = carModel;
        }

        #endregion


        #region Navigation Menu

        public void UserListShow()
        {
            if(UserListForm != null && NewUserForm != null)
            {
                NewUserForm.Visibility = Visibility.Collapsed;
                UserListForm.Visibility = Visibility.Visible;
            }
        }

        public void UserNewFormShow()
        {
            if(UserListForm != null && NewUserForm != null)
            {
                UserListForm.Visibility = Visibility.Collapsed;
                NewUserForm.Visibility = Visibility.Visible;
            }
        }

        #endregion


        #region Users List Form

        private List<EmployeeModel> _usersCollection;

        private BindableCollection<EmployeeModel> _users;

        public Grid UserListForm { get; set; }

        public string NameSearch { get; set; }

        public string LastNameSearch { get; set; }

        public BindableCollection<EmployeeModel> UserList
        {
            get { return _users; }
            set 
            { 
                _users = value;
                NotifyOfPropertyChange(() => UserList);
            }
        }

        public void UserListGridLoaded(Grid source)
        {
            UserListForm = source;
            UserListForm.Visibility = Visibility.Visible;
        }

        public void SearchUser()
        {
            // TODO: Function to filter users
        }

        public void UserChoose(EmployeeModel user)
        {
            // TODO: Function to get user and move to next form
        }

        #endregion


        #region New User Form

        public Grid NewUserForm { get; set; }

        public RegisterModel RegisterFormModel { get; set; }

        public void NewUserGridLoaded(Grid source)
        {
            NewUserForm = source;
            NewUserForm.Visibility = Visibility.Collapsed;
        }

        public void ClearForm()
        {
            // TODO: Function to clear entire form
        }

        public void Register()
        {
            // TODO: Function to register new user
        }

        #endregion
    }
}
