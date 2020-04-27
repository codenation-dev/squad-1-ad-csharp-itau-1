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
    public class UserStore : IUserStore<User>, IUserRoleStore<User>, IUserPasswordStore<User>, IUserEmailStore<User>
    {
        private readonly ItaLogContext _contexto;

        public UserStore(ItaLogContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _contexto.Users.AddAsync(user, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userFind = await FindByIdAsync(user.Id.ToString(), cancellationToken);
            if (user != null)
            {
                _contexto.Users.Remove(userFind);
                await _contexto.SaveChangesAsync(cancellationToken);
            }

            return IdentityResult.Success;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.Users.FindAsync(Convert.ToInt32(userId));
        }

        public async Task<User> FindByNameAsync(string nomalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.Users.FirstOrDefaultAsync(r => r.NormalizedUserName == nomalizedUserName, cancellationToken);
        }       

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }        

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.FromResult(0);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var roleFind = await _contexto.Users.FindAsync(user.Id, cancellationToken);

            if (roleFind != null)
            {
                roleFind.UserName = user.UserName;
                roleFind.Email = user.Email;       

                await _contexto.SaveChangesAsync(cancellationToken);
            }

            return IdentityResult.Success;
        }

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public async Task<User> FindByEmailAsync(string Email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.Users.FirstOrDefaultAsync(r => r.Email == Email, cancellationToken);
        }


        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var normalizedName = roleName.ToUpper();
            var role = await _contexto.Roles.FirstOrDefaultAsync(r => r.Name == normalizedName, cancellationToken);
            if (role == null)
            {
                await _contexto.Roles.AddAsync(new Role() { Name = roleName }, cancellationToken);
            }

            if (!await _contexto.UserRoles.AnyAsync(ur => ur.RoleId == role.Id && ur.UserId == user.Id, cancellationToken))
            {
                await _contexto.UserRoles.AddAsync(new UserRole() { RoleId = role.Id, UserId = user.Id });
                await _contexto.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var userRole = await _contexto.UserRoles.FirstOrDefaultAsync(r => r.Role.Name == roleName.ToUpper() && r.UserId == user.Id, cancellationToken);
            if (userRole != null)
            {
                _contexto.UserRoles.Remove(userRole);
                await _contexto.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await (from userRole in _contexto.UserRoles
                          join role in _contexto.Roles on userRole.RoleId equals role.Id
                          where userRole.UserId == user.Id
                          select role.Name).Distinct().ToListAsync(cancellationToken);
        }

        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.UserRoles.AnyAsync(ur => ur.UserId == user.Id && ur.Role.Name == roleName.ToUpper(), cancellationToken);
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await (from userRole in _contexto.UserRoles
                          join user in _contexto.Users on userRole.UserId equals user.Id
                          join role in _contexto.Roles on userRole.RoleId equals role.Id
                          where role.Name == roleName.ToUpper()
                          select user).Distinct().ToListAsync(cancellationToken);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            return Task.FromResult(0);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password != null);
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;
            return Task.FromResult(0);
        }
    }
}
