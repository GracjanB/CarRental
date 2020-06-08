using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels.Rentals
{
    public class RentalDetailsViewModel : Screen
    {
		private readonly SimpleContainer _container;

		private readonly IAgencyClient _agencyClient;

		private readonly IMapper _mapper;

		private readonly IAuthenticatedUser _user;

		public RentalDetailsViewModel(SimpleContainer container, IAgencyClient agencyClient, IMapper mapper, IAuthenticatedUser user)
		{
			_container = container;
			_agencyClient = agencyClient;
			_mapper = mapper;
			_user = user;
		}

		private async Task<AgencyModel> LoadAgency(int id)
		{
			var agencyDto = await _agencyClient.GetAgenciesAsync(_user.TokenType, _user.AccessToken, "id", id.ToString());
			var agency = _mapper.Map<AgencyModel>(agencyDto.content[0]);

			return agency;
		}

		public async Task LoadRental(RentalDetailsModel rental)
		{
			Rental = rental;
			Rental.Agency = await LoadAgency(Rental.AgencyId);
			Rental.TargetAgency = await LoadAgency(Rental.TargetAgencyId);
		}

		private RentalDetailsModel _rental;

		public RentalDetailsModel Rental
		{
			get { return _rental; }
			set 
			{ 
				_rental = value;
				NotifyOfPropertyChange(() => Rental);
			}
		}

		public void FinishRent()
		{
			var finishRentalVM = _container.GetInstance<FinishRentalViewModel>();
			finishRentalVM.LoadRentalId(Rental.Id);
			var conductorObject = (MainViewModel)this.Parent;
			conductorObject.ActivateItem(finishRentalVM);
		}

		public void MoveBack()
		{
			var rentalsVM = _container.GetInstance<RentalsViewModel>();
			var conductorObject = (MainViewModel)this.Parent;
			conductorObject.ActivateItem(rentalsVM);
		}

	}
}
