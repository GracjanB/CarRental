using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormAdditionalDataViewModel : Screen
    {
		private BindableCollection<string> _agencies;

		public BindableCollection<string> Agencies
		{
			get { return _agencies; }
			set 
			{ 
				_agencies = value;
				NotifyOfPropertyChange(() => Agencies);
			}
		}

		public string SelectedAgency { get; set; }

		public int StartingMileage { get; set; }

		public void MoveBack()
		{
			// TODO: Function to get back
		}

		public void MoveForward()
		{
			// TODO: Function to move forward to summary
		}
	}
}
