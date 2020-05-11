using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageEmployeesViewModel : Screen
    {
		private SimpleContainer _container { get; set; }

		public AgencyManageEmployeesViewModel(SimpleContainer simpleContainer)
		{
			_container = simpleContainer;
			Employees = GenerateEmployees();
		}


        #region Top Menu

        public void NewEmployee()
		{
			var agencyManageNewEmployeeVM = _container.GetInstance<AgencyManageNewEmployeeViewModel>();
			var conductorObject = (AgencyManageViewModel) this.Parent;
			conductorObject.ActivateItem(agencyManageNewEmployeeVM);
		}

        #endregion


        #region Employees DataGrid

        private BindableCollection<EmployeeModel> _employees;

		public EmployeeModel SelectedEmployee { get; set; }

		public BindableCollection<EmployeeModel> Employees
		{
			get { return _employees; }
			set
			{
				_employees = value;
				NotifyOfPropertyChange(() => Employees);
			}
		}

		public void SelectEmployee()
		{
			if (SelectedEmployee != null)
			{
				// TODO: Display employee details view
			}
			else
			{
				MessageBox.Show("Wybierz odpowiedni element z listy");
			}
		}

		#endregion

		private BindableCollection<EmployeeModel> GenerateEmployees()
		{
			var employees = new BindableCollection<EmployeeModel>
			{
				new EmployeeModel
				{
					Id = 1,
					FirstName = "Jan",
					LastName = "Kowalski",
					Email = "j.kowalski@sample.com",
					PESEL = "01932912120213",
					IdCardNumber = "ACV34243",
					Role = "Pracownik biurowy"
				},
				new EmployeeModel
				{
					Id = 2,
					FirstName = "Wiesiu",
					LastName = "Nowak",
					Email = "j.nowak@sample.com",
					PESEL = "8342348932498",
					IdCardNumber = "ADS98323",
					Role = "Pracownik techniczny"
				},
				new EmployeeModel
				{
					Id = 2,
					FirstName = "Zbysiu",
					LastName = "Zbysiowski",
					Email = "z.zbysiowski@sample.com",
					PESEL = "342342343232",
					IdCardNumber = "SDI98983",
					Role = "Pracownik techniczny"
				},
			};

			return employees;
		}
	}
}
