using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageVehicleDetailsViewModel : Screen
    {
        private SimpleContainer _container { get; set; }

        public AgencyManageVehicleDetailsViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
        }

        public void LoadModel(CarModel carModel)
        {
            Car = carModel;
        }


        #region Model

        private CarModel _carModel;

		public CarModel Car
		{
			get { return _carModel; }
			set { _carModel = value; }
		}

        #endregion


        #region PopUp Menu

        public void EditCar()
        {
            // TODO: Show Edit Car Screen
        }

        public void CarPriceList()
        {
            // TODO: Show Car Price List Screen
        }

        public void BackToCarList()
        {
            var agencyManageVehiclesVM = _container.GetInstance<AgencyManageVehiclesViewModel>();
            var conductorObject = (AgencyManageViewModel) this.Parent;
            conductorObject.ActivateItem(agencyManageVehiclesVM);
        }

        #endregion
    }
}
