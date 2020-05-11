using Caliburn.Micro;
using CarRentalWPF.Models;
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

		public AgencyManageVehiclesViewModel(SimpleContainer simpleContainer)
		{
			_container = simpleContainer;
			Cars = GenerateCars();
		}


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


		private BindableCollection<CarModel> GenerateCars()
		{
			BindableCollection<CarModel> cars = new BindableCollection<CarModel>
			{
				new CarModel
				{
					Mark = "Toyota",
					Model = "Avensis",
					Type = "Kombi",
					Engine = "2.0",
					Power = 234,
					Mileage = 236546,
					VIN = "1C4BJWFG7EL118131",
					Plate = "KR 39932"
				},
				new CarModel
				{
					Mark = "Nissan",
					Model = "Micra",
					Type = "Sedan",
					Engine = "1.4",
					Power = 86,
					Mileage = 35242,
					VIN = "1J4GS48K16C269261",
					Plate = "KR 65755"
				},
				new CarModel
				{
					Mark = "Audi",
					Model = "A4",
					Type = "Sedan",
					Engine = "2.0",
					Power = 256,
					Mileage = 5645,
					VIN = "SCBZK14C9TCX46528",
					Plate = "KR 6873FG"
				},
				new CarModel
				{
					Mark = "BMW",
					Model = "Seria 5",
					Type = "Kombi",
					Engine = "3.0",
					Power = 316,
					Mileage = 557,
					VIN = "1N4AL3AP8DN490078",
					Plate = "KR 467GH1"
				},
			};

			return cars;
		}

	}
}
