using Caliburn.Micro;
using CarRentalWPF.Events;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.ViewModels.RentCar;

namespace CarRentalWPF.ViewModels
{
	public class RentCarFormAdditionalDataViewModel : Screen, IHandle<AgencySelectedEvent>
    {
		private readonly SimpleContainer _container;

		private readonly IEventAggregator _events;

		private readonly IWindowManager _windowManager;

		public RentalModel rental { get; set; }

		public RentCarFormAdditionalDataViewModel(SimpleContainer container, IEventAggregator eventAggregator, 
			IWindowManager windowManager)
		{
			_container = container;
			_events = eventAggregator;
			_windowManager = windowManager;
			_events.Subscribe(this);
		}

		public void LoadRental(RentalModel rentalModel)
		{
			rental = rentalModel;
		}

		#region Form Controls

		private string _agencyString;

		public int StartingMileage { get; set; }

		public int Deposit { get; set; }

		public string AgencyString
		{
			get { return _agencyString; }
			set
			{
				_agencyString = value;
				NotifyOfPropertyChange(() => AgencyString);
			}
		}

		public void MoveForward()
		{
			rental.Deposit = Deposit;
			rental.StartMileage = StartingMileage;

			var rentCarFormSummaryVM = _container.GetInstance<RentCarFormSummaryViewModel>();
			rentCarFormSummaryVM.LoadRental(rental);

			var conductorObject = (RentCarFormViewModel)this.Parent;
			conductorObject.ActivateItem(rentCarFormSummaryVM);
		}

		public void AgencyChoose()
		{
			var agencyChooseVM = _container.GetInstance<RentCarFormAgencyChoiceViewModel>();
			_windowManager.ShowDialog(agencyChooseVM);
		}

		#endregion

		#region Events

		public void Handle(AgencySelectedEvent agencySelectedEvent)
		{
			rental.TargetAgency = agencySelectedEvent.Agency;
			AgencyString = agencySelectedEvent.Agency.FullAddress;
		}

		#endregion

	}
}
