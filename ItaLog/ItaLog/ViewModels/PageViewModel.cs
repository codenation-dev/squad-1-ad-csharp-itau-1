using System.Collections.Generic;

namespace ItaLog.Api.ViewModels
{
    public class PageViewModel<T>
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
