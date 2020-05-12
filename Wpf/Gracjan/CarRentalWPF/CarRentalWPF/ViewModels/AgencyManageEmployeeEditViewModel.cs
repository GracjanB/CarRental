using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageEmployeeEditViewModel : Screen
    {
        private SimpleContainer _container { get; set; }

        public AgencyManageEmployeeEditViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
        }

        public void LoadModel(EmployeeModel employee)
        {
            // Change it to copy constructor
            Employee = employee;
        }


        #region Top Menu

        public void SaveEmployee()
        {
            // TODO: Make save employee request
        }

        public void MoveBack()
        {
            // Check if something changed on form
            // If so, then set a flag and change output of CanClose function
        }

        #endregion

        #region Employee Model

        private EmployeeModel _employee;

        public EmployeeModel Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        #endregion
    }
}
