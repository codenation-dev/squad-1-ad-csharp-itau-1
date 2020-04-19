using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void Add(LogViewModel entity)
        {
            _repository.Add(_mapper.Map<Log>(entity));
        }

        public void Archive(int id)
        {
            _repository.Archive(id);
        }

        public LogViewModel FindById(int id)
        {
            return _mapper.Map<LogViewModel>(_repository.FindById(id));
        }

        public IEnumerable<LogViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<LogViewModel>>(_repository.GetAll());
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }
    }
}
