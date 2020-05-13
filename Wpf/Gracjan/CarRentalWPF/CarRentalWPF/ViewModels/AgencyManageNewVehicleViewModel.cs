using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageNewVehicleViewModel : Screen
    {



        #region Top Menu Buttons

        public void SaveCar()
        {
            // TODO: Make function to save car
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
    }
}
