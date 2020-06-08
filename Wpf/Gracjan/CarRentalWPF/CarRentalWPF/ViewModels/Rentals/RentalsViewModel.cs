using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels.Rentals
{
    public class RentalsViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IRentClient _rentClient;

        private readonly IUserClient _userClient;

        private readonly ICarClient _carClient;

        private readonly IAuthenticatedUser _user;

        private readonly IMapper _mapper;

        public RentalsViewModel(SimpleContainer container, IRentClient rentClient, IUserClient userClient, ICarClient carClient, 
            IAuthenticatedUser user, IMapper mapper)
        {
            _container = container;
            _rentClient = rentClient;
            _userClient = userClient;
            _carClient = carClient;
            _user = user;
            _mapper = mapper;

            Rentals = new BindableCollection<RentalDetailsModel>();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadRentals();
        }

        private async Task LoadRentals()
        {
            var rentalsDto = await _rentClient.GetRentalsAsync(_user.TokenType, _user.AccessToken);
            Rentals = new BindableCollection<RentalDetailsModel>();

            foreach (var rental in rentalsDto.content)
            {
                var rentalObject = _mapper.Map<RentalDetailsModel>(rental);
                var carDto = await _carClient.GetCarsAsync(_user.TokenType, _user.AccessToken, "vin", rental.carVin);
                var userDto = await _userClient.GetUsersAsync(_user.TokenType, _user.AccessToken, "id", rental.userId.ToString());

                rentalObject.Car = _mapper.Map<CarModel>(carDto.content[0]);
                rentalObject.User = _mapper.Map<UserModel>(userDto.content[0]);

                Rentals.Add(rentalObject);
            }
        }

        #region Card Controls

        private BindableCollection<RentalDetailsModel> _rentals;

        public BindableCollection<RentalDetailsModel> Rentals
        {
            get { return _rentals; }
            set 
            { 
                _rentals = value;
                NotifyOfPropertyChange(() => Rentals);
            }
        }

        public async void RentDetails(RentalDetailsModel rentalDetailsModel)
        {
            var rentDetailsVM = _container.GetInstance<RentalDetailsViewModel>();
            await rentDetailsVM.LoadRental(rentalDetailsModel);
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(rentDetailsVM);
        }

        public void FinishRent(RentalDetailsModel rentalDetailsModel)
        {
            var finishRentalVM = _container.GetInstance<FinishRentalViewModel>();
            finishRentalVM.LoadRentalId(rentalDetailsModel.Id);
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(finishRentalVM);
        }

        #endregion

    }
}
