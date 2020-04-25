using AutoMapper;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Models;
using System.Linq;

namespace ItaLog.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            CreateMap<Log, LogViewModel>().ReverseMap();
            CreateMap<Log, LogEventViewModel>().ReverseMap();
            CreateMap<Level, LevelViewModel>().ReverseMap();
            CreateMap<Environment, EnvironmentViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Page<Log>, PageViewModel<LogItemPageViewModel>>();
            CreateMap<Log, LogItemPageViewModel>()
                .ForMember(dest => dest.EventsCount, opt => opt.MapFrom(src => src.Events.Count()))
                .ForMember(dest => dest.ErrorDate, opt => opt.MapFrom(src => src.Events.Last().ErrorDate));
        }
    }
}
