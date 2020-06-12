using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class CarsViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IAuthenticatedUser _user;

        private readonly ICarClient _carClient;

        private readonly IMapper _mapper;

        public CarsViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser, 
            ICarClient carClient, IMapper mapper)
        {
            _container = simpleContainer;
            _user = authenticatedUser;
            _carClient = carClient;
            _mapper = mapper;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadCars();
        }

        private async Task LoadCars()
        {
            var carResource = await _carClient.GetCarsAsync(_user.TokenType, _user.AccessToken, "agencyId", _user.AgencyId.ToString());
            Cars = new BindableCollection<CarModel>();

            foreach (var car in carResource.content)
                Cars.Add(_mapper.Map<CarModel>(car));
        }

        #region Car Card Operations

        private BindableCollection<CarModel> _cars;

        public BindableCollection<CarModel> Cars
        {
            get { return _cars; }
            set 
            { 
                _cars = value;
                NotifyOfPropertyChange(() => Cars);
            }
        }

        public void CarDetails(CarModel carModel)
        {
            var carDetailsVM = _container.GetInstance<CarDetailsViewModel>();
            carDetailsVM.LoadCar(carModel);
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(carDetailsVM);
        }

        public void CarRent(CarModel carModel)
        {
            var rentCarVM = _container.GetInstance<RentCarFormViewModel>();
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(rentCarVM);
        }

        #endregion

    }
}
