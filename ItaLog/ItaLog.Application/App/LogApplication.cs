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

        public IEnumerable<LogItemPageViewModel> GetAllNotArchived()
        {
            var logsItensPage = new List<LogItemPageViewModel>();
            return _repository
                .GetAllNotArchived()
                .Select(log => new LogItemPageViewModel()
                {
                    IdLog = log.Id,
                    Title = log.Title,
                    EventsCount = log.Events.Count(),
                    Origin = log.Origin,
                    Level = _mapper.Map<LevelViewModel>(log.Level),
                    Environment = _mapper.Map<EnvironmentViewModel>(log.Environment),
                    ErrorDate = log.Events.Last().ErrorDate
                });
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
