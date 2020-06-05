﻿using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Helpers;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormSummaryViewModel : Screen
    {
        private readonly IRentClient _rentClient;

        private readonly IMapper _mapper;

        private readonly IAuthenticatedUser _user;

        public RentCarFormSummaryViewModel(IRentClient rentClient, IMapper mapper, IAuthenticatedUser user)
        {
            _rentClient = rentClient;
            _mapper = mapper;
            _user = user;
        }

        public void LoadRental(RentalModel rental)
        {
            Rental = rental;
            FormDates();
            CompleteCost = Convert.ToDecimal(Rental.Deposit) + Rental.CalculatedCost;
        }

        private string _rentalStartDate;

        public string RentalStartDate
        {
            get { return _rentalStartDate; }
            set 
            { 
                _rentalStartDate = value;
                NotifyOfPropertyChange(() => RentalStartDate);
            }
        }

        private string _rentalEndDate;

        public string RentalEndDate
        {
            get { return _rentalEndDate; }
            set 
            {
                _rentalEndDate = value;
                NotifyOfPropertyChange(() => RentalEndDate);
            }
        }

        private decimal _completeCost;

        public decimal CompleteCost
        {
            get { return _completeCost; }
            set 
            { 
                _completeCost = value;
                NotifyOfPropertyChange(() => CompleteCost);
            }
        }




        private RentalModel _rental;

        public RentalModel Rental
        {
            get { return _rental; }
            set 
            { 
                _rental = value;
                NotifyOfPropertyChange(() => Rental);
            }
        }

        private void FormDates()
        {
            RentalStartDate = Extensions.ConvertToReprDate(Rental.RentalStartDate, Rental.RentalStartTime);
            RentalEndDate = Extensions.ConvertToReprDate(Rental.RentalEndDate, Rental.RentalEndTime);
        }
        

        public async Task MakeRental()
        {
            var rentalDto = _mapper.Map<NewRentalDto>(Rental);
            var result = await _rentClient.CreateRentAsync(rentalDto, _user.TokenType, _user.AccessToken);

            if (result)
                MessageBox.Show("HURAA");
            else
                MessageBox.Show("NOPE");
        }
    }
}
