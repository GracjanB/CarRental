using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageNewEmployeeViewModel : Screen
    {
        private SimpleContainer _container { get; set; }

        public AgencyManageNewEmployeeViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
            RegisterFormModel = new RegisterModel();
        }


        #region Top Menu 

        public void RegisterEmployee()
        {
            // TODO: Make function to register new employee
        }

        public void ClearForm()
        {
            // TODO: Make function to entire register form
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
            set { _registerFormModel = value; }
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
                       PhoneNumberValidationResult;
            }
        }


        #endregion
    }
}
