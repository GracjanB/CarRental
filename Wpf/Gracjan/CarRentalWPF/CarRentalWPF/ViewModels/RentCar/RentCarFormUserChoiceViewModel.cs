using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormUserChoiceViewModel : Screen
    {
        private SimpleContainer _container;

        private readonly IUserClient _userClient;

        private readonly IMapper _mapper;

        private readonly IAuthenticatedUser _user;

        public RentalModel rental { get; set; }

        
        public RentCarFormUserChoiceViewModel(SimpleContainer simpleContainer, IUserClient userClient, IMapper mapper, IAuthenticatedUser user)
        {
            _container = simpleContainer;
            _userClient = userClient;
            _mapper = mapper;
            _user = user;
            RegisterFormModel = new RegisterModel();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadUsers();
        }

        public void LoadRental(RentalModel rentalModel)
        {
            rental = rentalModel;
            Car = rental.Car;
        }

        private async Task LoadUsers()
        {
            var usersList = await _userClient.GetUsersAsync(_user.TokenType, _user.AccessToken, "role", "USER");
            UserList = new BindableCollection<UserModel>();

            foreach (var user in usersList.content)
                UserList.Add(_mapper.Map<UserModel>(user));
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

        private BindableCollection<UserModel> _users;

        public Grid UserListForm { get; set; }

        public string NameSearch { get; set; }

        public string LastNameSearch { get; set; }

        public BindableCollection<UserModel> UserList
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

        public void UserChoose(UserModel user)
        {
            rental.User = user;

            var rentCarFormDateChoice = _container.GetInstance<RentCarFormDateChoiceViewModel>();
            rentCarFormDateChoice.LoadRental(rental);

            var conductorObject = (RentCarFormViewModel)this.Parent;
            conductorObject.ActivateItem(rentCarFormDateChoice);
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

        public async void Register()
        {
            var newUserDto = _mapper.Map<NewUserDto>(RegisterFormModel);
            newUserDto.country = "Polska";
            Console.WriteLine();

            var result = await _userClient.CreateUserAsync(newUserDto, _user.TokenType, _user.AccessToken);

            if (result)
                MessageBox.Show("Everything good");
            else
                MessageBox.Show("Not good");
        }

        #endregion
    }
}
