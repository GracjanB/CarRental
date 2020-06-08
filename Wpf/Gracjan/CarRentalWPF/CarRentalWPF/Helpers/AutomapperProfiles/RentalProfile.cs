using AutoMapper;
using CarRentalWPF.Library.FromServerDto;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Helpers.AutomapperProfiles
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalDto, RentalDetailsModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Deposit, opt => opt.MapFrom(src => src.deposit))
                .ForMember(dest => dest.CalculatedPrice, opt => opt.MapFrom(src => src.calculatedPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.StartMileage, opt => opt.MapFrom(src => src.startMileage))
                .ForMember(dest => dest.EndMileage, opt => opt.MapFrom(src => src.endMileage))
                .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src => src.finalPrice))
                .ForMember(dest => dest.RentStartDate, opt => opt.MapFrom(src => src.rentStartDate))
                .ForMember(dest => dest.RentEndDate, opt => opt.MapFrom(src => src.rentEndDate))
                .ForMember(dest => dest.AgencyId, opt => opt.MapFrom(src => src.agencyId))
                .ForMember(dest => dest.TargetAgencyId, opt => opt.MapFrom(src => src.targetAgencyId));
        }
    }
}
