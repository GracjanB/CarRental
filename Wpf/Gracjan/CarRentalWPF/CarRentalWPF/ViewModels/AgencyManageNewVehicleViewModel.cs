using Caliburn.Micro;
using CarRentalWPF.Models;
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

        public AgencyManageNewVehicleViewModel()
        {
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

        public void SaveCar()
        {
            if(!string.IsNullOrEmpty(SelectedCarType))
            {
                // Procedure to save new car
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
