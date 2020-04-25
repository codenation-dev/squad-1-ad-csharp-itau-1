using ItaLog.Application.ViewModels;
using System.Collections.Generic;

namespace ItaLog.Application.Interface
{
    public interface IApiUserApplication
    {
        ApiUserViewModel FindById(int id);
        ApiUserViewModel FindByName(string name);
        ApiUserViewModel FindByEmail(string email);
        IEnumerable<ApiUserViewModel> GetAll();
    }
}
