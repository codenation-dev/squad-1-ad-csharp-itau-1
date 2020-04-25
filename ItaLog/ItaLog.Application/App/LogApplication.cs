using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Linq;
using System.Collections.Generic;

namespace ItaLog.Application.App
{
    public class LogApplication : ILogApplication
    {
        private readonly ILogRepository _repository;
        private readonly IMapper _mapper;

        public LogApplication(ILogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(LogEventViewModel entity)
        {
            var log = _mapper.Map<Log>(entity);
            log.Events = new List<Event>()
            {
                new Event()
                {
                    Detail = entity.Detail,
                    ErrorDate = entity.ErrorDate
                }
            };

            _repository.Add(log);
        }

        public void Archive(int id)
        {
            _repository.Archive(id);                       
        }

        public LogViewModel FindById(int id)
        {
            return _mapper.Map<LogViewModel>(_repository.FindById(id));
        }

        public PageViewModel<LogItemPageViewModel> GetPage(int pageNumber, int pageLength)
        {
            var logsItensPage = new List<LogItemPageViewModel>();
            var pageLog = _repository.GetPage(pageNumber, pageLength);
            return _mapper.Map<PageViewModel<LogItemPageViewModel>>(pageLog);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
