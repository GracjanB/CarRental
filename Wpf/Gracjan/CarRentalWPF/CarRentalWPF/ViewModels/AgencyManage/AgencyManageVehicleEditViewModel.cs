using Caliburn.Micro;
using CarRentalWPF.Models;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageVehicleEditViewModel : Screen
    {
        public void LoadModel(CarModel carModel)
        {
            Car = carModel;
        }

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


        #region Buttons

        public void MoveBack()
        {
            // TODO: Make function to identify calling object (Vehicle Details or Vehicle View)
        }

        public void ClearForm()
        {
            // TODO: Make function to clear the form
        }

        public void SaveCar()
        {
            // TODO: Make save car function
        }

        #endregion


        #region Validation Result

        private bool _markValidationResult;
        private bool _modelValidationResult;
        private bool _typeValidationResult;
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
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool ModelValidationResult
        {
            get { return _modelValidationResult; }
            set 
            {
                _modelValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool TypeValidationResult
        {
            get { return _typeValidationResult; }
            set 
            { 
                _typeValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool EngineValidationResult
        {
            get { return _engineValidationResult; }
            set 
            { 
                _engineValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool PowerValidationResult
        {
            get { return _powerValidationResult; }
            set 
            { 
                _powerValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool MileageValidationResult
        {
            get { return _mileageValidationResult; }
            set 
            { 
                _mileageValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool PlateValidationResult
        {
            get { return _plateValidationResult; }
            set 
            { 
                _plateValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool VINValidationResult
        {
            get { return _vinValidationResult; }
            set 
            { 
                _vinValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool OverallValidationResult
        {
            get
            {
                return MarkValidationResult &&
                       ModelValidationResult &&
                       TypeValidationResult &&
                       EngineValidationResult &&
                       PowerValidationResult &&
                       MileageValidationResult &&
                       PlateValidationResult &&
                       VINValidationResult;
            }
        }

        #endregion

    }
}
