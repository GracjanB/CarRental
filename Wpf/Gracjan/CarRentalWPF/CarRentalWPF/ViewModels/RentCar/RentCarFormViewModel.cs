using Caliburn.Micro;

namespace CarRentalWPF.ViewModels
{
    public class RentCarFormViewModel : Conductor<object>
    {
        private readonly SimpleContainer _container;

        public RentCarFormViewModel(SimpleContainer simpleContainer)
        {
            _container = simpleContainer;

            var rentCarFormCarChoiceVM = _container.GetInstance<RentCarFormCarChoiceViewModel>();
            ActivateItem(rentCarFormCarChoiceVM);
        }
    }
}
