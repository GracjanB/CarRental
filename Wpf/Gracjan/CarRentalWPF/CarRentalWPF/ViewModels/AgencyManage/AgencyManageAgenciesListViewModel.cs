using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Events;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageAgenciesListViewModel : Screen, IHandle<NewAgencyAddedEvent>
    {
        private readonly SimpleContainer _container;

        private readonly IWindowManager _windowManager;

        private readonly IAuthenticatedUser _user;

        private readonly IAgencyClient _agencyClient;

        private readonly IMapper _mapper;

        public AgencyManageAgenciesListViewModel(SimpleContainer container, IWindowManager windowManager, 
            IAuthenticatedUser user, IAgencyClient agencyClient, IMapper mapper)
        {
            _container = container;
            _windowManager = windowManager;
            _user = user;

            _agencyClient = agencyClient;
            _mapper = mapper;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadAgencies();
        }

        private async Task LoadAgencies()
        {
            AgenciesDto agenciesResource = null;

            try
            {
                agenciesResource = await _agencyClient.GetAgenciesAsync(_user.TokenType, _user.AccessToken);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Agencies = new BindableCollection<AgencyModel>();
            foreach (var agency in agenciesResource.content)
                Agencies.Add(_mapper.Map<AgencyModel>(agency));
        }

        public void NewAgency()
        {
            var newAgencyVM = _container.GetInstance<AgencyManageNewAgencyViewModel>();
            _windowManager.ShowDialog(newAgencyVM);
        }

        private BindableCollection<AgencyModel> _agencies;

        public BindableCollection<AgencyModel> Agencies
        {
            get { return _agencies; }
            set 
            { 
                _agencies = value;
                NotifyOfPropertyChange(() => Agencies);
            }
        }

        #region Snackbar PopUp Notification

        private Snackbar _snackbarNotification;

        public Snackbar SnackbarNotification
        {
            get { return _snackbarNotification; }
            set
            {
                _snackbarNotification = value;
                NotifyOfPropertyChange(() => SnackbarNotification);
            }
        }

        public void SnackbarLoaded(object sender)
        {
            SnackbarNotification = (Snackbar)sender;
        }

        private void SnackbarShowMessage(string message)
        {
            SnackbarNotification.MessageQueue = new SnackbarMessageQueue();
            SnackbarNotification.MessageQueue.Enqueue(message);
        }

        #endregion


        #region Events

        public async void Handle(NewAgencyAddedEvent newAgencyAddedEvent)
        {
            await LoadAgencies();
            SnackbarShowMessage("Pomyślnie dodano.");
        }

        #endregion
    }
}
