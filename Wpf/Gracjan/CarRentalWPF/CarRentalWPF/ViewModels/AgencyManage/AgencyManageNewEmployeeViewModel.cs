using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageNewEmployeeViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IUserClient _userClient;

        private readonly IAuthenticatedUser _user;

        private readonly IMapper _mapper;

        public AgencyManageNewEmployeeViewModel(SimpleContainer simpleContainer, IUserClient userClient,
            IAuthenticatedUser user, IMapper mapper)
        {
            _container = simpleContainer;
            _userClient = userClient;
            _user = user;
            _mapper = mapper;
            RegisterFormModel = new RegisterModel();
        }

        #region Top Menu 

        public bool CanRegisterEmployee
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
                       PhoneNumberValidationResult;
            }
        }

        public void RegisterEmployee()
        {
            // TODO: Make function to register new employee
        }

        public void MoveBack()
        {
            var agencyManageEmployeesVM = _container.GetInstance<AgencyManageEmployeesViewModel>();
            var conductorObject = (AgencyManageViewModel) this.Parent;
            conductorObject.ActivateItem(agencyManageEmployeesVM);
        }

        #endregion


        #region Register Form Model

        private RegisterModel _registerFormModel;

        public RegisterModel RegisterFormModel
        {
            get { return _registerFormModel; }
            set 
            { 
                _registerFormModel = value;
                NotifyOfPropertyChange(() => RegisterFormModel);
            }
        }

        #endregion


        #region Validation Results

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

        public bool FirstNameValidationResult
        {
            get { return _firstNameValidationResult; }
            set
            {
                _firstNameValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool LastNameValidationResult
        {
            get { return _lastNameValidationResult; }
            set
            {
                _lastNameValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool PESELValidationResult
        {
            get { return _peselValidationResult; }
            set
            {
                _peselValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool IdCardNumberValidationResult
        {
            get { return _idCardNumberValidationResult; }
            set
            {
                _idCardNumberValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool StreetValidationResult
        {
            get { return _streetValidationResult; }
            set
            {
                _streetValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool BuildingNoValidationResult
        {
            get { return _buildingNoValidationResult; }
            set
            {
                _buildingNoValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool FlatNoValidationResult
        {
            get { return _flatNoValidationResult; }
            set
            {
                _flatNoValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool PostalCodeValidationResult
        {
            get { return _postalCodeValidationResult; }
            set
            {
                _postalCodeValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool CityValidationResult
        {
            get { return _cityValidationResult; }
            set
            {
                _cityValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool EmailValidationResult
        {
            get { return _emailValidationResult; }
            set
            {
                _emailValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        public bool PhoneNumberValidationResult
        {
            get { return _phoneNumberValidationResult; }
            set
            {
                _phoneNumberValidationResult = value;
                NotifyOfPropertyChange(() => CanRegisterEmployee);
            }
        }

        #endregion
    }
}
