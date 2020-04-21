using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ItaLog.Domain.Models;
using ItaLog.Data.Context;

namespace ItaLog.Data.Store
{
    public class ApiUserStore : IUserStore<ApiUser>, IUserRoleStore<ApiUser>, IUserPasswordStore<ApiUser>
    {
        private readonly ItaLogContext _contexto;

        public ApiUserStore(ItaLogContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IdentityResult> CreateAsync(ApiUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _contexto.ApiUsers.AddAsync(user, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(ApiUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userFind = await FindByIdAsync(user.Id.ToString(), cancellationToken);
            if (user != null)
            {
                _contexto.ApiUsers.Remove(userFind);
                await _contexto.SaveChangesAsync(cancellationToken);
            }

            return IdentityResult.Success;
        }

        public async Task<ApiUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.ApiUsers.FindAsync(Convert.ToInt32(userId));
        }

        public async Task<ApiUser> FindByNameAsync(string Name, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.ApiUsers.FirstOrDefaultAsync(r => r.Name == Name, cancellationToken);
        }       

        public Task<string> GetUserIdAsync(ApiUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(ApiUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }        

        public Task SetUserNameAsync(ApiUser user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;
            return Task.FromResult(0);
        }

        public async Task<IdentityResult> UpdateAsync(ApiUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var roleFind = await _contexto.ApiUsers.FindAsync(user.Id, cancellationToken);

            if (roleFind != null)
            {
                roleFind.Name = user.Name;
                roleFind.Email = user.Email;       

                await _contexto.SaveChangesAsync(cancellationToken);
            }

            return IdentityResult.Success;
        }

        public Task SetEmailAsync(ApiUser user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(ApiUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public async Task<ApiUser> FindByEmailAsync(string Email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.ApiUsers.FirstOrDefaultAsync(r => r.Email == Email, cancellationToken);
        }


        public async Task AddToRoleAsync(ApiUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var normalizedName = roleName.ToUpper();
            var role = await _contexto.ApiRoles.FirstOrDefaultAsync(r => r.Name == normalizedName, cancellationToken);
            if (role == null)
            {
                await _contexto.ApiRoles.AddAsync(new ApiRole() { Name = roleName }, cancellationToken);
            }

            if (!await _contexto.UserRoles.AnyAsync(ur => ur.ApiRoleId == role.Id && ur.ApiUserId == user.Id, cancellationToken))
            {
                await _contexto.UserRoles.AddAsync(new UserRole() { ApiRoleId = role.Id, ApiUserId = user.Id });
                await _contexto.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task RemoveFromRoleAsync(ApiUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userRole = await _contexto.UserRoles.FirstOrDefaultAsync(r => r.ApiRole.Name == roleName.ToUpper() && r.ApiUserId == user.Id, cancellationToken);
            if (userRole != null)
            {
                _contexto.UserRoles.Remove(userRole);
                await _contexto.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IList<string>> GetRolesAsync(ApiUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await (from userRole in _contexto.UserRoles
                          join role in _contexto.ApiRoles on userRole.ApiRoleId equals role.Id
                          where userRole.ApiUserId == user.Id
                          select role.Name).Distinct().ToListAsync(cancellationToken);
        }

        public async Task<bool> IsInRoleAsync(ApiUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.UserRoles.AnyAsync(ur => ur.ApiUserId == user.Id && ur.ApiRole.Name == roleName.ToUpper(), cancellationToken);
        }

        public async Task<IList<ApiUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await (from userRole in _contexto.UserRoles
                          join user in _contexto.ApiUsers on userRole.ApiUserId equals user.Id
                          join role in _contexto.ApiRoles on userRole.ApiRoleId equals role.Id
                          where role.Name == roleName.ToUpper()
                          select user).Distinct().ToListAsync(cancellationToken);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public Task<string> GetNormalizedUserNameAsync(ApiUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public Task SetNormalizedUserNameAsync(ApiUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Name = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(ApiUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApiUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(ApiUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }
    }
}
