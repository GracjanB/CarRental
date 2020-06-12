using AutoMapper;
using CarRentalWPF.Library2.ToServerDto;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Helpers.AutomapperProfiles
{
    public class NewRentalProfile : Profile
    {
        public NewRentalProfile()
        {
            CreateMap<RentalModel, NewRentalDto>()
                .ForMember(dest => dest.carVin, opt => opt.MapFrom(src => src.Car.VIN))
                .ForMember(dest => dest.deposit, opt => opt.MapFrom(src => src.Deposit))
                .ForMember(dest => dest.rentStartDate, opt => opt.MapFrom(src => src.StartRentalDate))
                .ForMember(dest => dest.rentEndDate, opt => opt.MapFrom(src => src.EndRentalDate))
                .ForMember(dest => dest.startMileage, opt => opt.MapFrom(src => src.StartMileage))
                .ForMember(dest => dest.targetAgencyId, opt => opt.MapFrom(src => src.TargetAgency.Id))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.User.Id));
        }
    }
}
