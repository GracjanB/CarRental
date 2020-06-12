using Caliburn.Micro;
using CarRentalWPF.Models;

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
            var agencyManageVehicleEditVM = _container.GetInstance<AgencyManageVehicleEditViewModel>();
            agencyManageVehicleEditVM.LoadModel(this.Car);

            var conductorObject = (AgencyManageViewModel) this.Parent;
            conductorObject.ActivateItem(agencyManageVehicleEditVM);
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
