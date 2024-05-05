using AutoMapper;
using CityApp.Entites;
using CityApp.Models;

namespace CityApp.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CityDTO, CityResponseWithVehicle>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(x => x.Name))
                .ForMember(dest => dest.Population, opt => opt.MapFrom(x => x.Population))
                .ForMember(dest => dest.CommonVehicle, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.CommonVehicle) ? "Not specified" : x.CommonVehicle));
            CreateMap<CityDTO, CityResponseWithoutVehicle>();
        }
    }
}
