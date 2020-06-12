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
    public class NewCarProfile : Profile
    {
        public NewCarProfile()
        {
            CreateMap<CarModel, NewCarDto>()
                .ForMember(dest => dest.carType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.carVersion, opt => opt.MapFrom(src => src.Version))
                .ForMember(dest => dest.engineCapacity, opt => opt.MapFrom(src => src.Engine))
                .ForMember(dest => dest.horsePower, opt => opt.MapFrom(src => src.Power))
                .ForMember(dest => dest.registerPlate, opt => opt.MapFrom(src => src.Plate));
        }
    }
}
