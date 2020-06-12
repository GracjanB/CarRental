using Caliburn.Micro;
using CarRentalWPF.Library.ApiClient.Implementations;
using CarRentalWPF.User;
using System;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageRaportsViewModel : Screen
    {
        private readonly IReportClient _reportClient;

        private readonly IAuthenticatedUser _user;

        public AgencyManageRaportsViewModel(IReportClient reportClient, IAuthenticatedUser user)
        {
            _reportClient = reportClient;
            _user = user;
        }

        public DateTime SelectedDateFrom { get; set; } = DateTime.Today;

        public DateTime SelectedDateTo { get; set; } = DateTime.Today;
    }
}
