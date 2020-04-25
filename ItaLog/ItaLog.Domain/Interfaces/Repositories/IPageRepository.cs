using ItaLog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItaLog.Domain.Interfaces.Repositories
{
    public interface IPageRepository<T>
    {
        Page<T> GetPage(int pageNumber = 1, int pageLength = 20);
    }
}
