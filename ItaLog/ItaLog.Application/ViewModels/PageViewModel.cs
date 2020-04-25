using System.Collections.Generic;

namespace ItaLog.Application.ViewModels
{
    public class PageViewModel<T>
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int PageLength { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
