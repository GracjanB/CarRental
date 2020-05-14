using Caliburn.Micro;
using CarRentalWPF.Converters;
using CarRentalWPF.Library.ApiClient.CarResource;
using CarRentalWPF.Library.RequestsContentModels;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageVehiclesViewModel : Screen
    {
		private SimpleContainer _container { get; set; }

		private IAuthenticatedUser _user;

		private ICarClient _carClient;

		private IModelToRequestContentConverter _converter;

		private List<CarModel> CarsCollection;


		public AgencyManageVehiclesViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser, 
			ICarClient carClient, IModelToRequestContentConverter modelToRequestContentConverter)
		{
			_container = simpleContainer;
			_user = authenticatedUser;
			_carClient = carClient;
			_converter = modelToRequestContentConverter;
		}


        #region On View Loading

        protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadCars();

		}

		private async Task LoadCars()
		{
			var carResource = await _carClient.GetCars(_user.TokenType, _user.AccessToken, "agencyId", _user.AgencyId.ToString());
			CarsCollection = _converter.CarResourceConverter(carResource);

			Cars = new BindableCollection<CarModel>();
			foreach (var car in CarsCollection)
				Cars.Add(car);
		}

        #endregion


        #region Current Displayed Cars Collection

        private BindableCollection<CarModel> _cars;

		public BindableCollection<CarModel> Cars
		{
			get { return _cars; }
			set 
			{ 
				_cars = value;
				NotifyOfPropertyChange(() => Cars);
			}
		}

        #endregion


        #region Filter Options Menu

        private BindableCollection<string> _marks;
		private BindableCollection<string> _models;
		private BindableCollection<string> _status;

		public BindableCollection<string> Marks
		{
			get { return _marks; }
			set 
			{ 
				_marks = value;
				NotifyOfPropertyChange(() => Marks);
			}
		}

		public BindableCollection<string> Models
		{
			get { return _models; }
			set 
			{ 
				_models = value;
				NotifyOfPropertyChange(() => Models);
			}
		}

		public BindableCollection<string> Status
		{
			get { return _status; }
			set 
			{ 
				_status = value;
				NotifyOfPropertyChange(() => Status);
			}
		}

		public void FilterCars()
		{

		}

		public void NewCar()
		{
			var agencyManageNewVehicleVM = _container.GetInstance<AgencyManageNewVehicleViewModel>();
			var conductorObject = (AgencyManageViewModel) this.Parent;

			conductorObject.ActivateItem(agencyManageNewVehicleVM);
		}

		#endregion


		#region Car Data Template

		public void CarDetails(CarModel carModel)
		{
			var agencyManageVehicleDetailsVM = _container.GetInstance<AgencyManageVehicleDetailsViewModel>();
			agencyManageVehicleDetailsVM.LoadModel(carModel);

			var conductorObject = (AgencyManageViewModel) this.Parent;
			conductorObject.ActivateItem(agencyManageVehicleDetailsVM);
		}

		public void CarEdit(CarModel carModel)
		{
			var agencyManageVehicleEditVM = _container.GetInstance<AgencyManageVehicleEditViewModel>();
			agencyManageVehicleEditVM.LoadModel(carModel);

			var conductorObject = (AgencyManageViewModel) this.Parent;
			conductorObject.ActivateItem(agencyManageVehicleEditVM);
		}

		public void CarPriceList(CarModel carModel)
		{
			// TODO: Show Car Price List
		}

		#endregion
	}
}
