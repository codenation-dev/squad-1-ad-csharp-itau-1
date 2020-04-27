using AutoMapper;
using ItaLog.Application.Interface;
using ItaLog.Application.ViewModels;
using ItaLog.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace ItaLog.Application.App
{
    public class ApiUserApplication : IApiUserApplication
    {
        private readonly IApiUserRepository _repo;
        private readonly IMapper _mapper;

        public ApiUserApplication(IApiUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ApiUserViewModel FindByEmail(string email)
        {
            return _mapper.Map<ApiUserViewModel>(_repo.FindByEmail(email));
        }

        public ApiUserViewModel FindById(int id)
        {
            return _mapper.Map<ApiUserViewModel>(_repo.FindById(id));
        }

        public ApiUserViewModel FindByName(string name)
        {
            return _mapper.Map<ApiUserViewModel>(_repo.FindByName(name));
        }

        public IEnumerable<ApiUserViewModel> GetAll()
        {
            return _mapper.Map<List<ApiUserViewModel>>(_repo.GetAll());
        }
    }
}
