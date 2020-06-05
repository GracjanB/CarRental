using Caliburn.Micro;
using CarRentalWPF.Models;

namespace CarRentalWPF.ViewModels
{
	public class RentCarFormAdditionalDataViewModel : Screen
    {
		private readonly SimpleContainer _container;

		public RentCarFormAdditionalDataViewModel(SimpleContainer container)
		{
			Agencies = GenerateAgencies();
			_container = container;
		}

		public RentalModel rental { get; set; }

		private BindableCollection<string> _agencies;

		public BindableCollection<string> Agencies
		{
			get { return _agencies; }
			set 
			{ 
				_agencies = value;
				NotifyOfPropertyChange(() => Agencies);
			}
		}

		public string SelectedAgency { get; set; }

		public int StartingMileage { get; set; }

		public int Deposit { get; set; }

		public void MoveBack()
		{
			// TODO: Function to get back
		}

		public void MoveForward()
		{
			rental.Deposit = Deposit;
			rental.StartMileage = StartingMileage;
			rental.TargetAgency = new AgencyModel
			{
				Id = 2,
				City = "Wroclaw",
				Country = "Polska",
				Street = "someStreet",
				PostalCode = "35-213",
				HouseNo = "213",
				FlatNo = "123"
			};

			var rentCarFormSummaryVM = _container.GetInstance<RentCarFormSummaryViewModel>();
			rentCarFormSummaryVM.LoadRental(rental);

			var conductorObject = (RentCarFormViewModel)this.Parent;
			conductorObject.ActivateItem(rentCarFormSummaryVM);
		}

		public void LoadRental(RentalModel rentalModel)
		{
			rental = rentalModel;
		}

		private BindableCollection<string> GenerateAgencies()
		{
			BindableCollection<string> agencies = new BindableCollection<string>
			{
				"Agencja 1",
				"Agencja 2",
				"Agencja 3"
			};

			return agencies;
		}
	}
}
