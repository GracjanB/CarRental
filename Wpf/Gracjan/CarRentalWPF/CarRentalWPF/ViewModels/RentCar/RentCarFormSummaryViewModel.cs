using Caliburn.Micro;
using CarRentalWPF.Models;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormSummaryViewModel : Screen
    {
        public RentCarFormSummaryViewModel()
        {
        }

        private RentalModel _rental;

        public RentalModel Rental
        {
            get { return _rental; }
            set 
            { 
                _rental = value;
                NotifyOfPropertyChange(() => Rental);
            }
        }


        public void LoadRental(RentalModel rental)
        {
            Rental = rental;
        }

        public void MakeRental()
        {
            //var rentalDto = _converter.RentalFormConverter(Rental);
            //Console.WriteLine();
        }
    }
}
