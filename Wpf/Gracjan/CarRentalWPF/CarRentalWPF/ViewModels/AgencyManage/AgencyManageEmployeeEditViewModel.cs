using Caliburn.Micro;
using CarRentalWPF.Models;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageEmployeeEditViewModel : Screen
    {
        private readonly SimpleContainer _container;

        public AgencyManageEmployeeEditViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
        }

        public void LoadModel(EmployeeModel employee)
        {
            Employee = employee;
        }

        #region Top Menu

        public void SaveEmployee()
        {

        }

        public void MoveBack()
        {
            // Check if something changed on form
            // If so, then set a flag and change output of CanClose function
        }

        #endregion


        #region Employee Model

        private EmployeeModel _employee;

        public EmployeeModel Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        #endregion


        #region Validation Result

        private bool _firstNameValidationResult;
        private bool _lastNameValidationResult;
        private bool _peselValidationResult;
        private bool _idCardNumberValidationResult;
        private bool _streetValidationResult;
        private bool _buildingNoValidationResult;
        private bool _flatNoValidationResult;
        private bool _postalCodeValidationResult;
        private bool _cityValidationResult;
        private bool _emailValidationResult;
        private bool _phoneNumberValidationResult;
        private bool _roleValidationResult;

        public bool FirstNameValidationResult
        {
            get { return _firstNameValidationResult; }
            set
            {
                _firstNameValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool LastNameValidationResult
        {
            get { return _lastNameValidationResult; }
            set 
            { 
                _lastNameValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool PESELValidationResult
        {
            get { return _peselValidationResult; }
            set 
            { 
                _peselValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool IdCardNumberValidationResult
        {
            get { return _idCardNumberValidationResult; }
            set 
            { 
                _idCardNumberValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool StreetValidationResult
        {
            get { return _streetValidationResult; }
            set 
            {
                _streetValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool BuildingNoValidationResult
        {
            get { return _buildingNoValidationResult; }
            set 
            { 
                _buildingNoValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool FlatNoValidationResult
        {
            get { return _flatNoValidationResult; }
            set 
            { 
                _flatNoValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool PostalCodeValidationResult
        {
            get { return _postalCodeValidationResult; }
            set 
            { 
                _postalCodeValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool CityValidationResult
        {
            get { return _cityValidationResult; }
            set 
            { 
                _cityValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool EmailValidationResult
        {
            get { return _emailValidationResult; }
            set 
            { 
                _emailValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool PhoneNumberValidationResult
        {
            get { return _phoneNumberValidationResult; }
            set 
            { 
                _phoneNumberValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool RoleValidationResult
        {
            get { return _roleValidationResult; }
            set 
            { 
                _roleValidationResult = value;
                NotifyOfPropertyChange(() => OverallValidationResult);
            }
        }

        public bool OverallValidationResult
        {
            get
            {
                return FirstNameValidationResult &&
                       LastNameValidationResult &&
                       PESELValidationResult &&
                       IdCardNumberValidationResult &&
                       StreetValidationResult &&
                       BuildingNoValidationResult &&
                       FlatNoValidationResult &&
                       PostalCodeValidationResult &&
                       CityValidationResult &&
                       EmailValidationResult &&
                       PhoneNumberValidationResult &&
                       RoleValidationResult;
            }
        }

        #endregion
    }
}
