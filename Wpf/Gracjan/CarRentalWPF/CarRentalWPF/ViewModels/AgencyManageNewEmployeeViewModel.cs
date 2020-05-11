using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageNewEmployeeViewModel : Screen
    {
        private SimpleContainer _container { get; set; }

        public AgencyManageNewEmployeeViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;
            RegisterFormModel = new RegisterModel();
        }


        #region Top Menu 

        public void RegisterEmployee()
        {
            // TODO: Make function to register new employee
        }

        public void ClearForm()
        {
            // TODO: Make function to entire register form
        }

        public void MoveBack()
        {
            var agencyManageEmployeesVM = _container.GetInstance<AgencyManageEmployeesViewModel>();
            var conductorObject = (AgencyManageViewModel) this.Parent;
            conductorObject.ActivateItem(agencyManageEmployeesVM);
        }

        #endregion


        #region Register Form Model

        private RegisterModel _registerFormModel;

        public RegisterModel RegisterFormModel
        {
            get { return _registerFormModel; }
            set { _registerFormModel = value; }
        }

        #endregion
    }
}
