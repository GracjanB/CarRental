using AutoMapper;
using CarRentalWPF.Library.FromServerDto;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Helpers.AutomapperProfiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDto, CarModel>()
                .ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.carVersion))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.carType))
                .ForMember(dest => dest.Power, opt => opt.MapFrom(src => src.horsePower))
                .ForMember(dest => dest.Engine, opt => opt.MapFrom(src => src.engineCapacity))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.registerPlate))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.dailyPrice));
        }
    }
}
