using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using CarRentalWPF.Helpers;
using CarRentalWPF.ViewModels;
using CarRentalWPF.User;
using AutoMapper;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Models;
using CarRentalWPF.Library2.ApiClient.Implementations;
using CarRentalWPF.Library2.ApiClient;
using CarRentalWPF.Helpers.AutomapperProfiles;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.Library.FromServerDto;

namespace CarRentalWPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            ConventionManager.AddElementConvention<PasswordBox>(
            PasswordBoxHelper.BoundPasswordProperty,
            "Password",
            "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container.RegisterSingleton(typeof(IAuthenticatedUser), "AuthenticatedUser", typeof(AuthenticatedUser));
            _container.RegisterSingleton(typeof(ILoggedInUserModel), "LoggedInUserModel", typeof(LoggedInUserModel));

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAuthenticationService, AuthenticationService>()
                .Singleton<IUserClient, UserClient>()
                .Singleton<ICarClient, CarClient>()
                .Singleton<IAgencyClient, AgencyClient>()
                .Singleton<IRentClient, RentClient>();

            MapperConfiguration mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<LoginModel, UserLoginDto>();
                config.CreateMap<AgencyModel, NewAgencyDto>();
                config.CreateMap<AgencyDto, AgencyModel>();
                config.CreateMap<RegisterModel, NewUserDto>();
                config.CreateMap<UserDto, UserModel>();
                config.AddProfile(new UserProfile());
                config.AddProfile(new NewCarProfile());
                config.AddProfile(new NewRentalProfile());
                config.AddProfile(new CarProfile());
                config.AddProfile(new RentalProfile());
            });

            var Mapper = mapperConfig.CreateMapper();
            _container
                .RegisterInstance(typeof(IMapper), "automapper", Mapper);

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
