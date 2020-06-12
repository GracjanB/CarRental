using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageEmployeeEditViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IUserClient _userClient;

        private readonly IAuthenticatedUser _user;

        public AgencyManageEmployeeEditViewModel(SimpleContainer simpleContainer, IUserClient userClient, 
            IAuthenticatedUser user)
        {
            _container = simpleContainer;
            _userClient = userClient;
            _user = user;
        }

        public void LoadModel(EmployeeModel employee)
        {
            Employee = employee;
        }

        #region Top Menu

        public bool CanSaveEmployee
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

        public void SaveEmployee()
        {

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
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool LastNameValidationResult
        {
            get { return _lastNameValidationResult; }
            set 
            { 
                _lastNameValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool PESELValidationResult
        {
            get { return _peselValidationResult; }
            set 
            { 
                _peselValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool IdCardNumberValidationResult
        {
            get { return _idCardNumberValidationResult; }
            set 
            { 
                _idCardNumberValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool StreetValidationResult
        {
            get { return _streetValidationResult; }
            set 
            {
                _streetValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool BuildingNoValidationResult
        {
            get { return _buildingNoValidationResult; }
            set 
            { 
                _buildingNoValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool FlatNoValidationResult
        {
            get { return _flatNoValidationResult; }
            set 
            { 
                _flatNoValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool PostalCodeValidationResult
        {
            get { return _postalCodeValidationResult; }
            set 
            { 
                _postalCodeValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool CityValidationResult
        {
            get { return _cityValidationResult; }
            set 
            { 
                _cityValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool EmailValidationResult
        {
            get { return _emailValidationResult; }
            set 
            { 
                _emailValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool PhoneNumberValidationResult
        {
            get { return _phoneNumberValidationResult; }
            set 
            { 
                _phoneNumberValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        public bool RoleValidationResult
        {
            get { return _roleValidationResult; }
            set 
            { 
                _roleValidationResult = value;
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        #endregion
    }
}
