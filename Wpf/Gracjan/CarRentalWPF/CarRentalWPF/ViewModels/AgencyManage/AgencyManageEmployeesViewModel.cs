using Caliburn.Micro;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
	public class AgencyManageEmployeesViewModel : Screen
    {
		private readonly SimpleContainer _container;

		private readonly IAuthenticatedUser _user;

		private List<EmployeeModel> employees;

		public AgencyManageEmployeesViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser)
		{
			_container = simpleContainer;
			_user = authenticatedUser;
			Employees = GenerateEmployees();
		}


		protected override void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
		}

		private async void LoadUsers()
		{
			//UsersResource users = null;

			//try
			//{
			//	users = await _userClient.GetUsers(_user.TokenType, _user.AccessToken, "role", "MANAGER");
			//}
			//catch (ArgumentException ex)
			//{
			//	MessageBox.Show(ex.Message);
			//}

			////employees = _converter.UserResourceConverter(users);
			//LoadEmployeesToDisplay();
		}

		private void LoadEmployeesToDisplay()
		{
			Employees = new BindableCollection<EmployeeModel>();

			foreach (var employee in employees)
				Employees.Add(employee);
		}

		#region Top Menu

		public async void NewEmployee()
		{
			//var agencyManageNewEmployeeVM = _container.GetInstance<AgencyManageNewEmployeeViewModel>();
			//var conductorObject = (AgencyManageViewModel)this.Parent;
			//conductorObject.ActivateItem(agencyManageNewEmployeeVM);

			//try
			//{
			//	var result = await _userClient.GetUserById(_user.TokenType, _user.AccessToken, 6);
			//}
			//catch(ArgumentException ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}

			Console.WriteLine();
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
				var agencyManageEmployeeDetailsVM = _container.GetInstance<AgencyManageEmployeeDetailsViewModel>();
				agencyManageEmployeeDetailsVM.LoadModel(SelectedEmployee);

				var conductorObject = (AgencyManageViewModel) this.Parent;
				conductorObject.ActivateItem(agencyManageEmployeeDetailsVM);
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
					Role = "Pracownik biurowy",
					Street = "Poziomkowa",
					BuildingNo = "64B",
					FlatNo = 32,
					City = "Wrocław",
					PostalCode = "45-232",
					PhoneNumber = "198321932"
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
