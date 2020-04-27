using ItaLog.Data.Context;
using ItaLog.Domain.Models;
using System;
using System.Linq;
namespace ItaLog.Data.Seeds
{
    public class UserSeed
    {
        private readonly ItaLogContext _context;

        public UserSeed(ItaLogContext context)
        {
            _context = context;
        }

        public void Populate()
        {
            if(_context.Users.Any())            
                return;
           
            User u1 = new User
            {
                Id = 1,
                UserToken = Guid.NewGuid(),
                Name = "Admin",
                UserName = "admin@contato.com",
                NormalizedUserName = "ADMIN@CONTATO.COM",
                Email = "admin@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            User u2 = new User
            {
                Id = 2,
                UserToken = Guid.NewGuid(),
                Name = "Itau",
                UserName = "itau@contato.com",
                NormalizedUserName = "ITAU@CONTATO.COM",
                Email = "itau@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            User u3 = new User
            {
                Id = 3,
                UserToken = Guid.NewGuid(),
                Name = "Afonso",
                UserName = "afonso@contato.com",
                NormalizedUserName = "AFONSO@CONTATO.COM",
                Email = "afonso@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            User u4 = new User
            {
                Id = 4,
                UserToken = Guid.NewGuid(),
                Name = "André",
                UserName = "andre@contato.com",
                NormalizedUserName = "ANDRE@CONTATO.COM",
                Email = "andre@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            User u5 = new User
            {
                Id = 5,
                UserToken = Guid.NewGuid(),
                Name = "Brunna",
                UserName = "brunna@contato.com",
                NormalizedUserName = "BRUNNA@CONTATO.COM",
                Email = "brunna@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            User u6 = new User
            {
                Id = 6,
                UserToken = Guid.NewGuid(),
                Name = "Bruno",
                UserName = "bruno@contato.com",
                NormalizedUserName = "BRUNO@CONTATO.COM",
                Email = "bruno@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };
            User u7 = new User
            {
                Id = 7,
                UserToken = Guid.NewGuid(),
                Name = "Carlos",
                UserName = "carlos@contato.com",
                NormalizedUserName = "CARLOS@CONTATO.COM",
                Email = "carlos@contato.com",
                EmailConfirmed = true,
                Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==",
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now
            };

            _context.Users.AddRange(u1, u2, u3, u4, u5, u6, u7);
            _context.SaveChanges();
        }


        //public static User[] GetData()
        //{
        //    int idValue = 0;

        //    return new User[]
        //    {
        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Admin", UserName = "admin@contato.com",
        //           NormalizedUserName = "ADMIN@CONTATO.COM", Email = "admin@contato.com", EmailConfirmed = true,
        //           Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Itau", UserName = "itau@contato.com",
        //            NormalizedUserName = "ITAU@CONTATO.COM", Email = "itau@contato.com", EmailConfirmed = true,
        //            Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Afonso", UserName = "afonso@contato.com",
        //            NormalizedUserName = "AFONSO@CONTATO.COM", Email = "afonso@contato.com", EmailConfirmed = true,
        //            Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "André", UserName = "andre@contato.com",
        //            NormalizedUserName = "ANDRE@CONTATO.COM", Email = "andre@contato.com", EmailConfirmed = true,
        //            Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Brunna", UserName = "brunna@contato.com",
        //            NormalizedUserName = "BRUNNA@CONTATO.COM", Email = "brunna@contato.com", EmailConfirmed = true,
        //            Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Bruno", UserName = "bruno@contato.com",
        //           NormalizedUserName = "BRUNO@CONTATO.COM", Email = "bruno@contato.com", EmailConfirmed = true,
        //          Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now},

        //        new User { Id = ++idValue, UserToken = Guid.NewGuid(), Name = "Carlos", UserName = "carlos@contato.com",
        //            NormalizedUserName = "CARLOS@CONTATO.COM", Email = "carlos@contato.com", EmailConfirmed = true,
        //            Password = "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now}
        //    };
        //}
    }
}
