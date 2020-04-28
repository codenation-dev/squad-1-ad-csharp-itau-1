using System;
using System.ComponentModel.DataAnnotations;

namespace ItaLog.Domain.Models
{
    public class LogFilter
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int? LevelId { get; set; }
        public string Title { get; set; }
        public string Origin { get; set; }
    }
}
