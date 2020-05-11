using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // TODO: Make function to save car credentials
        }

        #endregion

    }
}
