using Caliburn.Micro;
using CarRentalWPF.Converters;
using CarRentalWPF.Library.ApiClient.CarResource;
using CarRentalWPF.Library.Models;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageNewVehicleViewModel : Screen
    {
        private IModelToRequestContentConverter _converter { get; set; }

        private IAuthenticatedUser _user { get; set; }

        private ICarClient _carClient { get; set; }


        public AgencyManageNewVehicleViewModel(IModelToRequestContentConverter modelToRequestContentConverter, IAuthenticatedUser authenticatedUser, ICarClient carClient)
        {
            _converter = modelToRequestContentConverter;
            _user = authenticatedUser;
            _carClient = carClient;
            Car = new CarModel();
            GenerateCarTypes();
        }


        #region On Initialize

        private void GenerateCarTypes()
        {
            CarTypes = new BindableCollection<string>(Types);
        }

        #endregion


        #region Top Menu Buttons

        public bool CanSaveCar
        {
            get
            {
                return !(MarkValidationResult &&
                       ModelValidationResult &&
                       EngineValidationResult &&
                       PowerValidationResult &&
                       MileageValidationResult &&
                       PlateValidationResult &&
                       VINValidationResult);
            }
        }

        public async void SaveCar()
        {
            if(!string.IsNullOrEmpty(SelectedCarType))
            {
                int priceListId;
                bool result;

                try
                {
                    priceListId = _carClient.CreatePriceList(Car.PricePerDay, _user.TokenType, _user.AccessToken).Result;
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                var carRequestModel = prepareRequestData(Car, SelectedCarType, priceListId);

                try
                {
                    result = await _carClient.CreateCar(carRequestModel, _user.TokenType, _user.AccessToken);
                }
                catch(ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if(result)
                {
                    MessageBox.Show("This worked.");
                }
            }
            else
            {
                MessageBox.Show("Didn't chose any car type");
            }
        }

        public void ClearForm()
        {
            // TODO: Make function to clear form
        }

        private NewCarContent prepareRequestData(CarModel car, string carType, int priceListId)
        {
            var agencyId = _user.AgencyId;
            car.Type = carType;
            var requestContent = _converter.CarConverter(car, agencyId, priceListId);

            return requestContent;
        }

        #endregion


        #region Form Fields

        private CarModel _carModel;
        private BindableCollection<string> _carTypes;
        private string _selectedCarType;

        public CarModel Car
        {
            get { return _carModel; }
            set
            {
                _carModel = value;
                NotifyOfPropertyChange(() => Car);
            }
        }

        public BindableCollection<string> CarTypes
        {
            get { return _carTypes; }
            set 
            { 
                _carTypes = value;
                NotifyOfPropertyChange(() => CarTypes);
            }
        }

        public string SelectedCarType
        {
            get { return _selectedCarType; }
            set 
            { 
                _selectedCarType = value;
                NotifyOfPropertyChange(() => CarTypes);
            }
        }

        #endregion


        #region Validation Results

        private bool _markValidationResult;
        private bool _modelValidationResult;
        private bool _engineValidationResult;
        private bool _powerValidationResult;
        private bool _mileageValidationResult;
        private bool _plateValidationResult;
        private bool _vinValidationResult;

        public bool MarkValidationResult
        {
            get { return _markValidationResult; }
            set
            {
                _markValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        public bool ModelValidationResult
        {
            get { return _modelValidationResult; }
            set
            {
                _modelValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        public bool EngineValidationResult
        {
            get { return _engineValidationResult; }
            set
            {
                _engineValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        public bool PowerValidationResult
        {
            get { return _powerValidationResult; }
            set
            {
                _powerValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        public bool MileageValidationResult
        {
            get { return _mileageValidationResult; }
            set
            {
                _mileageValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        public bool PlateValidationResult
        {
            get { return _plateValidationResult; }
            set
            {
                _plateValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        public bool VINValidationResult
        {
            get { return _vinValidationResult; }
            set
            {
                _vinValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveCar);
            }
        }

        #endregion


        #region Resources

        private readonly string[] Types = new string[]
        {
            "COMBI",
            "VAN",
            "SUV",
            "SEDAN"
        };

        #endregion
    }
}
