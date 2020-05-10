using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageViewModel : Conductor<object>
    {
        private SimpleContainer _container { get; set; }


        public AgencyManageViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;

            var agencyManageHomeVM = _container.GetInstance<AgencyManageHomeViewModel>();
            ActivateItem(agencyManageHomeVM);
        }


        #region Left Menu Buttons

        public void HomeScreenShow()
        {
            var agencyManageHomeVM = _container.GetInstance<AgencyManageHomeViewModel>();
            ChangeActiveItem(agencyManageHomeVM, true);
        }

        public void EmployeesScreenShow()
        {
            var agencyManageEmployeesVM = _container.GetInstance<AgencyManageEmployeesViewModel>();
            ChangeActiveItem(agencyManageEmployeesVM, true);
        }

        public void VehicleFleetScreenShow()
        {
            var agencyManageVehiclesVM = _container.GetInstance<AgencyManageVehiclesViewModel>();
            ChangeActiveItem(agencyManageVehiclesVM, true);
        }

        public void ReportsScreenShow()
        {
            var agencyManageRaportsVM = _container.GetInstance<AgencyManageRaportsViewModel>();
            ChangeActiveItem(agencyManageRaportsVM, true);
        }

        #endregion
    }
}
