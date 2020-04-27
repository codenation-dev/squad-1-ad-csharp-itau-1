using ItaLog.Domain.Models;

namespace ItaLog.Data.Seeds
{
    public static class RoleSeed
    {
        public static Role[] GetData()
        {
            int idValue = 0;

            return new Role[]
            {
                new Role { Id = ++idValue, Name = "User" },
                new Role { Id = ++idValue, Name = "Administrator" },                
            };
        }
    }
}
