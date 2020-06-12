using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Helpers;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using MaterialDesignThemes.Wpf;
using System;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormDateChoiceViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IAuthenticatedUser _user;

        private readonly IRentClient _rentClient;

        private readonly IMapper _mapper;

        public RentCarFormDateChoiceViewModel(SimpleContainer simpleContainer, IAuthenticatedUser user,
            IRentClient rentClient, IMapper mapper)
        {
            _container = simpleContainer;
            _user = user;

            _rentClient = rentClient;
            _mapper = mapper;
        }

        private bool CompareDates(DateTime dateFrom, DateTime dateTo)
        {
            bool output = false;
            int result = DateTime.Compare(dateFrom, dateTo);

            if (result > 0)
                output = true;

            return output;
        }

        public void LoadRental(RentalModel rentalModel)
        {
            rental = rentalModel;
        }

        #region Form Controls

        public DateTime SelectedDateFrom { get; set; } = DateTime.Today;

        public DateTime SelectedTimeFrom { get; set; }

        public DateTime SelectedDateTo { get; set; } = DateTime.Today;

        public DateTime SelectedTimeTo { get; set; }

        private bool DatesValid { get; set; } = false;

        public RentalModel rental { get; set; }

        private string _basePrice;

        public string BasePrice
        {
            get { return _basePrice; }
            set
            {
                _basePrice = value;
                NotifyOfPropertyChange(() => BasePrice);
            }
        }

        public bool CanMoveForward
        {
            get
            {
                return DatesValid;
            }
        }

        public void MoveForward()
        {
            rental.RentalStartDate = SelectedDateFrom;
            rental.RentalStartTime = SelectedTimeFrom;
            rental.RentalEndDate = SelectedDateTo;
            rental.RentalEndTime = SelectedTimeTo;

            var rentCarFormAdditionalDataVM = _container.GetInstance<RentCarFormAdditionalDataViewModel>();
            rentCarFormAdditionalDataVM.LoadRental(rental);

            var conductorObject = (RentCarFormViewModel)this.Parent;
            conductorObject.ActivateItem(rentCarFormAdditionalDataVM);
        }

        public async void CheckPrice()
        {
            var areDatesValid = CompareDates(SelectedDateTo, SelectedDateFrom);

            if (areDatesValid)
            {
                var fullDateFrom = Extensions.ConvertToZonedDate(SelectedDateFrom, SelectedTimeFrom);
                var fullDateTo = Extensions.ConvertToZonedDate(SelectedDateTo, SelectedTimeTo);

                rental.StartRentalDate = fullDateFrom;
                rental.EndRentalDate = fullDateTo;

                var calculateCostDto = new CalculateCostDto
                {
                    carVin = rental.Car.VIN,
                    rentStartDate = fullDateFrom,
                    rentEndDate = fullDateTo
                };

                CalculatedCostDto calculatedCost = null;

                try
                {
                    calculatedCost = await _rentClient.CalculateCostAsync(calculateCostDto, _user.TokenType, _user.AccessToken);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                rental.CalculatedCost = calculatedCost.cost;
                BasePrice = calculatedCost.cost.ToString("F");
                DatesValid = true;
            }
            else
            {
                SnackbarShowMessage("Daty są błędne. Spróbuj ponownie");
                DatesValid = false;
            }

            NotifyOfPropertyChange(() => CanMoveForward);
        }

        #endregion

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

    }
}
