using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
	public class AgencyManageVehiclesViewModel : Screen
    {
		private readonly SimpleContainer _container;

		private readonly IAuthenticatedUser _user;

		private readonly ICarClient _carClient;

		private readonly IMapper _mapper;


		public AgencyManageVehiclesViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser, 
			ICarClient carClient, IMapper mapper)
		{
			_container = simpleContainer;
			_user = authenticatedUser;
			_carClient = carClient;
			_mapper = mapper;
		}

        #region On View Loading

        protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadCars();
		}

		private async Task LoadCars()
		{
			var carResource = await _carClient.GetCarsAsync(_user.TokenType, _user.AccessToken, "agencyId", _user.AgencyId.ToString());
			Cars = new BindableCollection<CarModel>();

			foreach (var car in carResource.content)
				Cars.Add(_mapper.Map<CarModel>(car));
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

		public void NewCar()
		{
			var agencyManageNewVehicleVM = _container.GetInstance<AgencyManageNewVehicleViewModel>();
			var conductorObject = (AgencyManageViewModel) this.Parent;

			conductorObject.ActivateItem(agencyManageNewVehicleVM);
		}

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

		#endregion
	}
}
