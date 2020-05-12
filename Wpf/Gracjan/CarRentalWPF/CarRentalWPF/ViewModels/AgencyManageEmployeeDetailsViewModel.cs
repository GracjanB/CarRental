using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageEmployeeDetailsViewModel : Screen
    {
        private SimpleContainer _container { get; set; }

        public AgencyManageEmployeeDetailsViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
        }

        public void LoadModel(EmployeeModel employeeModel)
        {
            Employee = employeeModel;
        }

        #region Employee Model

        private EmployeeModel _employee;

        public EmployeeModel Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        #endregion


        #region PopUp Menu

        public void EditEmployee()
        {
            var agencyManageEmployeeEditVM = _container.GetInstance<AgencyManageEmployeeEditViewModel>();
            agencyManageEmployeeEditVM.LoadModel(Employee);

            var conductorObject = (AgencyManageViewModel) this.Parent;
            conductorObject.ActivateItem(agencyManageEmployeeEditVM);
        }

        public void MoveBack()
        {
            var agencyManageEmployeesVM = _container.GetInstance<AgencyManageEmployeesViewModel>();

            var conductorObject = (AgencyManageViewModel) this.Parent;
            conductorObject.ActivateItem(agencyManageEmployeesVM);
        }

        #endregion
    }
}
