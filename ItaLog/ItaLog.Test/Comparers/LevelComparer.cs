using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Test.Comparers
{
    public class LevelComparer : IEqualityComparer<Level>
    {
        public bool Equals(Level x, Level y)
        {
            return x.Id == y.Id
                && x.Description == y.Description;
        }

        public int GetHashCode(Level obj)
        {
            return (obj.Id.ToString() + '|' + obj.Description.ToString()).GetHashCode();
        }
    }
}