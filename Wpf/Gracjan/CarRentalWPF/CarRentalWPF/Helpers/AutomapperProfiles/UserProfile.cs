using AutoMapper;
using CarRentalWPF.Library2.FromServerDto;
using CarRentalWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Helpers.AutomapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserInfoDto, EmployeeModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.user.firstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.user.lastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.user.email))
                .ForMember(dest => dest.PESEL, opt => opt.MapFrom(src => src.user.pesel))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.user.role))
                .ForMember(dest => dest.IdCardNumber, opt => opt.MapFrom(src => src.user.idCardNumber))
                .ForMember(dest => dest.AgencyId, opt => opt.MapFrom(src => src.user.agencyId));
        }
    }
}
