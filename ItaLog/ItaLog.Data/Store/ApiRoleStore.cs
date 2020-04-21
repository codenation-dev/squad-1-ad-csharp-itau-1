using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ItaLog.Domain.Models;
using ItaLog.Data.Context;

namespace ItaLog.Data.Store
{
    public class ApiRoleStore : IRoleStore<ApiRole>
    {
        protected readonly ItaLogContext _contexto;

        public ApiRoleStore(ItaLogContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IdentityResult> CreateAsync(ApiRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await _contexto.ApiRoles.AddAsync(role, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(ApiRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var roleFind = await _contexto.ApiRoles.FindAsync(role.Id, cancellationToken);

            if (roleFind != null)
            {
                roleFind.Name = role.Name;

                await _contexto.SaveChangesAsync(cancellationToken);
            }

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(ApiRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var roleFind = await FindByIdAsync(role.Id.ToString(), cancellationToken);
            if (roleFind != null)
            {
                _contexto.ApiRoles.Remove(roleFind);
                await _contexto.SaveChangesAsync(cancellationToken);

            }

            return IdentityResult.Success;
        }

        public Task<string> GetRoleIdAsync(ApiRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(ApiRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(ApiRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            return Task.FromResult(0);
        }

        public Task<string> GetNormalizedRoleNameAsync(ApiRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(ApiRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.Name = normalizedName;
            return Task.FromResult(0);
        }

        public async Task<ApiRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.ApiRoles.FindAsync(roleId, cancellationToken);
        }

        public async Task<ApiRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _contexto.ApiRoles.FirstOrDefaultAsync(r => r.Name == normalizedRoleName, cancellationToken);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
