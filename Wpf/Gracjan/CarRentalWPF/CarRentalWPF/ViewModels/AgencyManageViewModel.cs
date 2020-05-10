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
            // TODO: Activate main user control
        }


        #region Left Menu Buttons

        public void HomeScreenShow()
        {
            // TODO: Show home screen
            MessageBox.Show("Not implemented");
        }

        public void EmployeesScreenShow()
        {
            // TODO: Show employees screen
            MessageBox.Show("Not implemented");
        }

        public void VehicleFleetScreenShow()
        {
            // TODO: Show vehicle fleet screen
            MessageBox.Show("Not implemented");
        }

        public void ReportsScreenShow()
        {
            // TODO: Show reports screen
            MessageBox.Show("Not implemented");
        }

        #endregion
    }
}
