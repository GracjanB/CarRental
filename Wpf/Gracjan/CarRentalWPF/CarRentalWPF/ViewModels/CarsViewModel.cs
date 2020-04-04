using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class CarsViewModel : Screen
    {
        public BindableCollection<CarsModel> Cars { get; set; }

        public CarsViewModel()
        {

        }
    }
}
