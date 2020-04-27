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
    public class LevelApplication : ILevelApplication
    {
        private readonly ILevelRepository _repository;
        private readonly IMapper _mapper;
        public LevelApplication(ILevelRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(LevelViewModel entity)
        {
            _repository.Add(_mapper.Map<Level>(entity));
        }

        public void Update(LevelViewModel entity)
        {
            _repository.Update(_mapper.Map<Level>(entity));
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public LevelViewModel FindById(int id)
        {
            return _mapper.Map<LevelViewModel>(_repository.FindById(id));
        }

        public IEnumerable<LevelViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<LevelViewModel>>(_repository.GetAll());
        }
    }
}
