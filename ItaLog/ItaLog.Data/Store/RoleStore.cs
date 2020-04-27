using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ItaLog.Domain.Models;
using ItaLog.Data.Context;

namespace ItaLog.Data.Store
{
    public class RoleStore : IRoleStore<Role>
    {
        protected readonly ItaLogContext _contexto;

        public RoleStore(ItaLogContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _contexto.Roles.AddAsync(role, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var roleFind = await _contexto.Roles.FindAsync(role.Id, cancellationToken);

            if (roleFind != null)
            {
                roleFind.Name = role.Name;

                await _contexto.SaveChangesAsync(cancellationToken);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var roleFind = await FindByIdAsync(role.Id.ToString(), cancellationToken);
            if (roleFind != null)
            {
                _contexto.Roles.Remove(roleFind);
                await _contexto.SaveChangesAsync(cancellationToken);

            }

            return IdentityResult.Success;
        }

        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            role.Name = normalizedName;
            return Task.FromResult(0);
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.Roles.FindAsync(roleId, cancellationToken);
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.Roles.FirstOrDefaultAsync(r => r.Name == normalizedRoleName, cancellationToken);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
