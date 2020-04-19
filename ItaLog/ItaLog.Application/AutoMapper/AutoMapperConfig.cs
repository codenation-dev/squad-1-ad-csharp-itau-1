using AutoMapper;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
