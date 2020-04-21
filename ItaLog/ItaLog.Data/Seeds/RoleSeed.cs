using ItaLog.Domain.Models;

namespace ItaLog.Data.Seeds
{
    public static class RoleSeed
    {
        public static ApiRole[] GetData()
        {
            int idValue = 0;

            return new ApiRole[]
            {
                new ApiRole { Id = ++idValue, Name = "User" },
                new ApiRole { Id = ++idValue, Name = "Administrator" },                
            };
        }
    }
}
