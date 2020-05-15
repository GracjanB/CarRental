using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormDateChoiceViewModel : Screen
    {
        public DateTime SelectedDateFrom { get; set; } = DateTime.Today;

        public DateTime SelectedTimeFrom { get; set; }

        public DateTime SelectedDateTo { get; set; } = DateTime.Today;

        public DateTime SelectedTimeTo { get; set; }

        public string BasePrice { get; set; }

        public void MoveBack()
        {

        }

        public void MoveForward()
        {

        }
    }
}
