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

        private IWindowManager _windowManager { get; set; }

        public MainViewModel(SimpleContainer simpleContainer, IWindowManager windowManager)
        {
            _simpleContainer = simpleContainer;
            _windowManager = windowManager;
        }

        public void Cars_MouseLeftButtonDown()
        {
            ActivateItem(_simpleContainer.GetInstance<CarsViewModel>());
        }

        public void MainView_MouseLeftButtonDown()
        {
            ActivateItem(_simpleContainer.GetInstance<RentCarFormViewModel>());
        }

        public void LoginButtonPopupBoxClick()
        {
            LoginViewModel loginVM = _simpleContainer.GetInstance<LoginViewModel>();
            _windowManager.ShowDialog(loginVM);
        }

        public void RegisterButtonPopupBoxClick()
        {
            RegisterViewModel registerVM = _simpleContainer.GetInstance<RegisterViewModel>();
            _windowManager.ShowDialog(registerVM);
        }
    }
}
