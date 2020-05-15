using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormViewModel : Conductor<object>
    {
        private SimpleContainer _container;

        public RentCarFormViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;

            var rentCarFormCarChoiceVM = _container.GetInstance<RentCarFormCarChoiceViewModel>();
            ActivateItem(rentCarFormCarChoiceVM);
        }
    }
}
