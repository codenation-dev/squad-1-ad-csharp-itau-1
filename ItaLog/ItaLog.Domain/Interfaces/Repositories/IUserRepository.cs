using ItaLog.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>, IUserStore<User>, IUserRoleStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>, IDisposable
    {
        User FindByEmail(string email);
        Page<User> GetPage(PageFilter pageFilter);
    }
}
