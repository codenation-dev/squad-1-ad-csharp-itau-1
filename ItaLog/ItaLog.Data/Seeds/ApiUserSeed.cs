using ItaLog.Domain.Models;
using System;

namespace ItaLog.Data.Seeds
{
    public static class ApiUserSeed
    {
        public static ApiUser[] GetData()
        {
            int idValue = 0;

            return new ApiUser[]
            {
                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Admin", UserName = "admin@contato.com",
                    NormalizedUserName = "ADMIN@CONTATO.COM", Email = "admin@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Itau", UserName = "itau@contato.com",
                    NormalizedUserName = "ITAU@CONTATO.COM", Email = "itau@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Afonso", UserName = "afonso@contato.com",
                    NormalizedUserName = "AFONSO@CONTATO.COM", Email = "afonso@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "André", UserName = "andre@contato.com",
                    NormalizedUserName = "ANDRE@CONTATO.COM", Email = "andre@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Brunna", UserName = "brunna@contato.com",
                    NormalizedUserName = "BRUNNA@CONTATO.COM", Email = "brunna@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Bruno", UserName = "bruno@contato.com",
                    NormalizedUserName = "BRUNO@CONTATO.COM", Email = "bruno@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

                new ApiUser { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Carlos", UserName = "carlos@contato.com",
                    NormalizedUserName = "CARLOS@CONTATO.COM", Email = "carlos@contato.com", EmailConfirmed = true,
                    Password = "P@ssword123", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now}
            };
        }
    }
}
