using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormCarChoiceViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IAuthenticatedUser _user;

        private readonly ICarClient _carClient;

        private readonly IMapper _mapper;

        public RentalModel rental { get; set; }


        public RentCarFormCarChoiceViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser,
            ICarClient carClient, IMapper mapper)
        {
            _container = simpleContainer;
            _user = authenticatedUser;
            _carClient = carClient;
            _mapper = mapper;

            rental = new RentalModel();
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

        public void CarChoose(CarModel carModel)
        {
            if (rental == null)
                rental = new RentalModel();
            rental.Car = carModel;

            var rentCarFormUserChoice = _container.GetInstance<RentCarFormUserChoiceViewModel>();
            rentCarFormUserChoice.LoadRental(rental);

            var conductorObject = (RentCarFormViewModel) this.Parent;
            conductorObject.ActivateItem(rentCarFormUserChoice);
        }

        #endregion

    }
}
