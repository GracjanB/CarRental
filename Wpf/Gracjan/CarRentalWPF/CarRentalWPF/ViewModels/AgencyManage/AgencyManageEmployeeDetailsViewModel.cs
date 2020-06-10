using Caliburn.Micro;
using CarRentalWPF.Models;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageEmployeeDetailsViewModel : Screen
    {
        private readonly SimpleContainer _container;

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
            set 
            { 
                _employee = value;
                NotifyOfPropertyChange(() => Employee);
            }
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
