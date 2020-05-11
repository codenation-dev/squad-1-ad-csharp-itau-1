using ItaLog.Domain.Models;
using System.Collections.Generic;

namespace ItaLog.Test.Comparers
{
    public class LogComparer : IEqualityComparer<Log>
    {
        public bool Equals(Log x, Log y)
        {
            return x.Id == y.Id
                && x.Title == y.Title
                && x.Origin == y.Origin
                && x.Archived == y.Archived
                && x.LevelId == y.LevelId
                && x.EnvironmentId == y.EnvironmentId
                && x.ApiUserId == y.ApiUserId;           
        }

        public int GetHashCode(Log obj)
        {
           return(obj.Id.ToString() + '|' + obj.Title.ToString()
                + '|' + obj.Origin.ToString() + '|' + obj.Archived.ToString()
                + '|' + obj.LevelId.ToString()+ '|' + obj.EnvironmentId.ToString()
                + '|' + obj.ApiUserId.ToString()).GetHashCode();            
        }
    }
}