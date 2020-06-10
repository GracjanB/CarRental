using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Events;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels.RentCar
{
    public class RentCarFormAgencyChoiceViewModel : Screen
    {
        private readonly IAgencyClient _agencyClient;

        private readonly IEventAggregator _events;

        private readonly IMapper _mapper;

        private readonly IAuthenticatedUser _user;

        public RentCarFormAgencyChoiceViewModel(IEventAggregator eventAggregator, IAgencyClient agencyClient,
            IMapper mapper, IAuthenticatedUser user)
        {
            _events = eventAggregator;
            _agencyClient = agencyClient;
            _mapper = mapper;
            _user = user;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadAgencies();
        }

        private async Task LoadAgencies()
        {
            var agenciesDto = await _agencyClient.GetAgenciesAsync(_user.TokenType, _user.AccessToken);
            Agencies = new BindableCollection<AgencyModel>();

            foreach (var agency in agenciesDto.content)
                Agencies.Add(_mapper.Map<AgencyModel>(agency));
        }

        #region Form Controls

        private BindableCollection<AgencyModel> _agencies;
        private AgencyModel _selectedAgency;

        public BindableCollection<AgencyModel> Agencies
        {
            get { return _agencies; }
            set
            {
                _agencies = value;
                NotifyOfPropertyChange(() => Agencies);
            }
        }

        public AgencyModel SelectedAgency
        {
            get { return _selectedAgency; }
            set
            {
                _selectedAgency = value;
                NotifyOfPropertyChange(() => SelectedAgency);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public bool CanSave
        {
            get
            {
                bool output = false;

                if (SelectedAgency != null)
                    output = true;

                return output;
            }
        }

        public void Save()
        {
            _events.PublishOnUIThread(new AgencySelectedEvent(SelectedAgency));
            TryClose();
        }

        #endregion

    }
}
