using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Domain.Models
{
    public class Page<T>
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
