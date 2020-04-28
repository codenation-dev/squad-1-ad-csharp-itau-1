using System;
using System.ComponentModel.DataAnnotations;

namespace ItaLog.Domain.Models
{
    public class PageFilter
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PageNumber { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int PageLength { get; set; } = 20;
    }
}
