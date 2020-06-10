using AutoMapper;
using Caliburn.Micro;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
	public class AgencyManageEmployeesViewModel : Screen
    {
		private readonly SimpleContainer _container;

		private readonly IAuthenticatedUser _user;

		private readonly IUserClient _userClient;

		private readonly IMapper _mapper;

		public AgencyManageEmployeesViewModel(SimpleContainer simpleContainer, IAuthenticatedUser authenticatedUser, 
			IUserClient userClient, IMapper mapper)
		{
			_container = simpleContainer;
			_user = authenticatedUser;
			_userClient = userClient;
			_mapper = mapper;
		}


		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadEmployees();
		}

		private async Task LoadEmployees()
		{
			UsersDto users = null;

			try
			{
				users = await _userClient.GetUsersAsync(_user.TokenType, _user.AccessToken, "agencyId", _user.AgencyId.ToString());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			Employees = new BindableCollection<EmployeeModel>();

			foreach (var user in users.content)
				Employees.Add(_mapper.Map<EmployeeModel>(user));
		}

		#region Top Menu

		public void NewEmployee()
		{
			var newEmployeeVM = _container.GetInstance<AgencyManageNewEmployeeViewModel>();
			var conductorObject = (AgencyManageViewModel)this.Parent;
			conductorObject.ActivateItem(newEmployeeVM);
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

	}
}
