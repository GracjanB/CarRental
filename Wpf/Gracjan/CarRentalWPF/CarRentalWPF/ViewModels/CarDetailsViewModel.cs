using Caliburn.Micro;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class CarDetailsViewModel : Screen
    {
        private readonly SimpleContainer _container;

        public CarDetailsViewModel(SimpleContainer container)
        {
            _container = container;
        }

        public void LoadCar(CarModel carModel)
        {
            Car = carModel;
        }

        private CarModel _car;

        public CarModel Car
        {
            get { return _car; }
            set 
            { 
                _car = value;
                NotifyOfPropertyChange(() => Car);
            }
        }

        public void MoveBack()
        {
            var carsVM = _container.GetInstance<CarsViewModel>();
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(carsVM);
        }

        public void RentCar()
        {
            var rentCarVM = _container.GetInstance<RentCarFormViewModel>();
            var conductorObject = (MainViewModel)this.Parent;
            conductorObject.ActivateItem(rentCarVM);
        }

    }
}
