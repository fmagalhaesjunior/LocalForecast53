using AutoMapper;
using LocalForecast53.Application.Inputs;
using LocalForecast53.Core.Entities;

namespace LocalForecast53.Application.Mapping
{
    public class ForecastMapper : Profile
    {
        public ForecastMapper()
        {
            //Mapear de ForecastInput para CallHistory
            CreateMap<ForecastInput, CallHistory>()
                .ForMember(dest => dest.CallTime, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude));
        }
    }
}
