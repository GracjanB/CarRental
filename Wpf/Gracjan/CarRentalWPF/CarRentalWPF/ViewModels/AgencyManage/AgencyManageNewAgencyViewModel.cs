using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Events;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageNewAgencyViewModel : Screen
    {
        private readonly IEventAggregator _events;

        private readonly IAuthenticatedUser _user;

        private readonly IAgencyClient _agencyClient;

        private readonly IMapper _mapper;

        public AgencyManageNewAgencyViewModel(IEventAggregator eventAggregator, IAuthenticatedUser user,
            IAgencyClient agencyClient, IMapper mapper)
        {
            _events = eventAggregator;
            _user = user;
            _agencyClient = agencyClient;
            _mapper = mapper;
        }

        #region Form Controls

        public string Street { get; set; }

        public string HouseNo { get; set; }

        public string FlatNo { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public int MaxCarQuantity { get; set; }

        public async Task SaveAgency()
        {
            var agencyModel = new AgencyModel
            {
                Street = Street,
                HouseNo = HouseNo,
                FlatNo = FlatNo,
                City = City,
                PostalCode = PostalCode,
                Country = Country,
                maxCarQuantity = MaxCarQuantity
            };

            var newAgencyDto = _mapper.Map<NewAgencyDto>(agencyModel);

            try
            {
                await _agencyClient.CreateAgencyAsync(newAgencyDto, _user.TokenType, _user.AccessToken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _events.PublishOnUIThread(new NewAgencyAddedEvent());
        }

        #endregion
    }
}
