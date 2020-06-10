using Caliburn.Micro;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageViewModel : Conductor<object>
    {
        private readonly SimpleContainer _container;

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

        public void AgenciesListShow()
        {
            var agencyManageAgenciesListVM = _container.GetInstance<AgencyManageAgenciesListViewModel>();
            ChangeActiveItem(agencyManageAgenciesListVM, true);
        }

        #endregion
    }
}
