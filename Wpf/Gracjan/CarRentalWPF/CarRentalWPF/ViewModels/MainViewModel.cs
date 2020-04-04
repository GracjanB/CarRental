using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        private SimpleContainer _simpleContainer { get; set; }

        public MainViewModel(SimpleContainer simpleContainer)
        {
            _simpleContainer = simpleContainer;
        }

        public void Cars_MouseLeftButtonDown()
        {
            ActivateItem(_simpleContainer.GetInstance<CarsViewModel>());
        }
    }
}
