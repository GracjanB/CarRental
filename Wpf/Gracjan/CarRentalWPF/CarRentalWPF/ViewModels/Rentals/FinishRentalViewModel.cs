using Caliburn.Micro;
using CarRentalWPF.Helpers;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.ViewModels.Rentals
{
    public class FinishRentalViewModel : Screen
    {
        private readonly SimpleContainer _container;

        private readonly IRentClient _rentClient;

        private readonly IAuthenticatedUser _user;

        private int rentalId { get; set; }

        public FinishRentalViewModel(SimpleContainer container, IRentClient rentClient, IAuthenticatedUser user)
        {
            _container = container;
            _rentClient = rentClient;
            _user = user;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            var actions = await _rentClient.GetActionsAsync(_user.TokenType, _user.AccessToken);
            Actions = new BindableCollection<string>();
            foreach (var action in actions)
                Actions.Add(action);
        }

        public void LoadRentalId(int id)
        {
            rentalId = id;
        }

        #region Form Controls

        public int EndMileage { get; set; }

        public decimal FinalPrice { get; set; }

        public DateTime SelectedEndDate { get; set; } = DateTime.Today;

        public DateTime SelectedEndTime { get; set; }

        public decimal TechnicalSupportCost { get; set; }

        public string TechnicalSupportComment { get; set; }

        public string SelectedAction { get; set; }

        private List<string> ActionsList { get; set; } = new List<string>();

        private string _actionsString;

        public string ActionsString
        {
            get { return _actionsString; }
            set 
            { 
                _actionsString = value;
                NotifyOfPropertyChange(() => ActionsString);
            }
        }

        private BindableCollection<string> _actions;

        public BindableCollection<string> Actions
        {
            get { return _actions; }
            set 
            { 
                _actions = value;
                NotifyOfPropertyChange(() => Actions);
            }
        }

        public void AddAction()
        {
            if(SelectedAction != null && !ActionsList.Contains(SelectedAction))
            {
                ActionsList.Add(SelectedAction);
                ActionsString += SelectedAction + "\n";
                NotifyOfPropertyChange(() => ActionsString);
            }
        }

        public void FinishRental()
        {
            var finishRentalDto = new FinishRentDto
            {
                endMileage = EndMileage,
                finalPrice = FinalPrice,
                rentEndDate = Extensions.ConvertToZonedDate(SelectedEndDate, SelectedEndTime),
                technicalSupportContent = new TechnicalSupportContent
                {
                    comment = TechnicalSupportComment,
                    technicalSupportCost = TechnicalSupportCost,
                    technicalSupportActions = ActionsList
                }
            };

            // TODO: finish rent function
        }

        #endregion
    }
}
