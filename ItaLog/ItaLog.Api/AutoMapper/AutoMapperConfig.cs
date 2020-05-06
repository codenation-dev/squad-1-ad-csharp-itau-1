using AutoMapper;
using ItaLog.Api.ViewModels;
using ItaLog.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItaLog.Api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => x.AllowNullCollections = true);
        }

        public AutoMapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Log, LogViewModel>().ReverseMap();
            CreateMap<Level, LevelViewModel>().ReverseMap();
            CreateMap<Environment, EnvironmentViewModel>().ReverseMap();
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Page<User>, PageViewModel<UserViewModel>>();
            CreateMap<Page<Level>, PageViewModel<LevelViewModel>>();
            CreateMap<Page<Environment>, PageViewModel<EnvironmentViewModel>>();
            CreateMap<Page<Log>, PageViewModel<LogItemPageViewModel>>();
            CreateMap<Log, LogItemPageViewModel>()
                .ForMember(dest => dest.EventsCount, opt => opt.MapFrom(src => src.Events.Count()))
                .ForMember(dest => dest.ErrorDate, opt => opt.MapFrom(src => src.Events.Last().ErrorDate));
            CreateMap<LogEventViewModel, Log>()
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => new List<Event>()
                {
                    new Event(){ Detail = src.Detail, ErrorDate = src.ErrorDate }
                }));
        }
    }
}
