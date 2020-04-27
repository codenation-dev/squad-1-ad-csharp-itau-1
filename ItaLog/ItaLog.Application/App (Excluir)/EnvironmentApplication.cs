using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Application.App
{
    public class EnvironmentApplication : IEnvironmentApplication
    {
        private readonly IEnvironmentRepository _repository;
        private readonly IMapper _mapper;

        public EnvironmentApplication(IEnvironmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(EnvironmentViewModel entity)
        {
            //_repository.Add(_mapper.Map<Environment>(entity));
        }

        public void Update(EnvironmentViewModel entity)
        {
            _repository.Update(_mapper.Map<Environment>(entity));
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public EnvironmentViewModel FindById(int id)
        {
            return _mapper.Map<EnvironmentViewModel>(_repository.FindById(id));
        }

        public IEnumerable<EnvironmentViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<EnvironmentViewModel>>(_repository.GetAll());
        }
    }
}
