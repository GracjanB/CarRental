using Caliburn.Micro;
using System.Windows;

namespace CarRentalWPF.ViewModels
{
    public class AgencyManageHomeViewModel : Screen
    {
        #region Contact Information Card

        private string _fullStreetName;
        private string _city;
        private string _country;


        public string FullStreetName
        {
            get { return _fullStreetName; }
            set 
            { 
                _fullStreetName = value;
                NotifyOfPropertyChange(() => FullStreetName);
            }
        }

        public string City
        {
            get { return _city; }
            set 
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Country
        {
            get { return _country; }
            set 
            { 
                _country = value;
                NotifyOfPropertyChange(() => Country);
            }
        }

        public void EditAddress()
        {
            MessageBox.Show("Not implemented.");
        }

        #endregion


        #region Employees Information Card

        private int _employeesAmount;
        private int _currentActiveEmployees;


        public int EmployeesAmount
        {
            get { return _employeesAmount; }
            set 
            { 
                _employeesAmount = value;
                NotifyOfPropertyChange(() => EmployeesAmount);
            }
        }

        public int CurrentActiveEmployees
        {
            get { return _currentActiveEmployees; }
            set 
            { 
                _currentActiveEmployees = value;
                NotifyOfPropertyChange(() => CurrentActiveEmployees);
            }
        }

        #endregion


        #region Vehicle Fleet Information Card

        private int _vehiclesAmount;
        private int _vehiclesAvailable;
        private int _rentedVehicles;
        private int _vehiclesInRepair;

        public int VehiclesAmount
        {
            get { return _vehiclesAmount; }
            set 
            {
                _vehiclesAmount = value;
                NotifyOfPropertyChange(() => VehiclesAmount);
            }
        }

        public int VehiclesAvailable
        {
            get { return _vehiclesAvailable; }
            set 
            { 
                _vehiclesAvailable = value;
                NotifyOfPropertyChange(() => VehiclesAvailable);
            }
        }

        public int RentedVehicles
        {
            get { return _rentedVehicles; }
            set 
            { 
                _rentedVehicles = value;
                NotifyOfPropertyChange(() => RentedVehicles);
            }
        }

        public int VehiclesInRepair
        {
            get { return _vehiclesInRepair; }
            set 
            { 
                _vehiclesInRepair = value;
                NotifyOfPropertyChange(() => VehiclesInRepair);
            }
        }

        #endregion
    }
}
