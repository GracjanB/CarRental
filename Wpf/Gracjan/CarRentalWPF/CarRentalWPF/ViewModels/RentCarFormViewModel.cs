using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormViewModel : Screen
    {
        public BindableCollection<int> Days { get; set; }

        public BindableCollection<string> Months { get; set; }

        public BindableCollection<int> Years { get; set; }

        public RentCarFormViewModel()
        {
            LoadDays();
            LoadMonths();
            LoadYears();

        }

        private void LoadDays()
        {
            Days = new BindableCollection<int>();
            for (int i = 1; i < 32; i++)
                Days.Add(i);
        }

        private void LoadMonths()
        {
            Months = new BindableCollection<string>();
            Months.Add("Styczeń");
            Months.Add("Luty");
            Months.Add("Marzec");
            Months.Add("Kwiecień");
            Months.Add("Maj");
            Months.Add("Czerwiec");
            Months.Add("Lipiec");
            Months.Add("Sierpień");
            Months.Add("Wrzesień");
            Months.Add("Październik");
            Months.Add("Listopad");
            Months.Add("Grudzień");
        }

        private void LoadYears()
        {
            Years = new BindableCollection<int>();
            for (int i = 1901; i < 2003; i++)
                Years.Add(i);
        }
    }
}
