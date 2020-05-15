using Caliburn.Micro;
using CarRentalWPF.Converters;
using CarRentalWPF.Library.ApiClient.CarResource;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormCarChoiceViewModel : Screen
    {
        private SimpleContainer _container;

        private IAuthenticatedUser _user; 

        private ICarClient _carClient;

        private IModelToRequestContentConverter _converter;

        private List<CarModel> CarsCollection;

        public RentCarFormCarChoiceViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser, ICarClient carClient,
            IModelToRequestContentConverter converter)
        {
            _container = simpleContainer;
            _user = authenticatedUser;
            _carClient = carClient;
            _converter = converter;

            // For testing
            Cars = GenerateCars();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            //await LoadCars();
        }

        private async Task LoadCars()
        {
            var carResource = await _carClient.GetCars(_user.TokenType, _user.AccessToken, "agencyId", _user.AgencyId.ToString());
            CarsCollection = _converter.CarResourceConverter(carResource);

            Cars = new BindableCollection<CarModel>();
            foreach (var car in CarsCollection)
                Cars.Add(car);
        }

        #region Car Card Operations

        // Current displayed cars collection
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
            // TODO: Function to display car details view
        }

        public void CarChoose(CarModel carModel)
        {
            // TODO: Function to move next view
        }

        #endregion


        #region Filter Menu 

        private BindableCollection<string> _marks;
        private BindableCollection<string> _models;
        private BindableCollection<string> _types;
        private int _selectedPrice;
        private int _priceMinValue;
        private int _priceMaxValue;

        public string SelectedMark { get; set; }

        public string SelectedModel { get; set; }

        public string SelectedType { get; set; }


        public BindableCollection<string> Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }

        public BindableCollection<string> Models
        {
            get { return _models; }
            set { _models = value; }
        }

        public BindableCollection<string> Types
        {
            get { return _types; }
            set { _types = value; }
        }

        public int PriceMinValue
        {
            get { return _priceMinValue; }
            set { _priceMinValue = value; }
        }

        public int PriceMaxValue
        {
            get { return _priceMaxValue; }
            set { _priceMaxValue = value; }
        }

        public int SelectedPrice
        {
            get { return _selectedPrice; }
            set { _selectedPrice = value; }
        }

        public void Filter()
        {
            // TODO: Make filter function
        }

        #endregion

        private BindableCollection<CarModel> GenerateCars()
        {
            BindableCollection<CarModel> cars = new BindableCollection<CarModel>
            {
                new CarModel
                {
                    Mark = "Toyota",
                    Model = "Avensis",
                    Type = "COMBI",
                    Engine = 1997,
                    Power = 234,
                    Mileage = 384223,
                    Plate = "KR 29383",
                    PricePerDay = 43
                },
                new CarModel
                {
                    Mark = "Nissan",
                    Model = "Micra",
                    Type = "Hatchback",
                    Engine = 1368,
                    Power = 78,
                    Mileage = 5665,
                    Plate = "KR 2433D",
                    PricePerDay = 84
                },
                new CarModel
                {
                    Mark = "Mercedes-Benz",
                    Model = "C200",
                    Type = "SEDAN",
                    Engine = 3000,
                    Power = 234,
                    Mileage = 384223,
                    Plate = "KR 3242G",
                    PricePerDay = 56
                },
            };

            return cars;
        }
    }
}
