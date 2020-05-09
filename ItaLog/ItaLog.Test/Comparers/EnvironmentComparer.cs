using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Test.Comparers
{
    public class EnvironmentComparer : IEqualityComparer<Environment>
    {
        public bool Equals(Environment x, Environment y)
        {
            return x.Id == y.Id
                && x.Description == y.Description;
        }

        public int GetHashCode(Environment obj)
        {
            return (obj.Id.ToString() + '|' + obj.Description.ToString()).GetHashCode();
        }
    }
}