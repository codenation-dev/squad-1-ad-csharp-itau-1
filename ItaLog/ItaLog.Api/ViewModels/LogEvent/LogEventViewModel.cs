using System;
using System.ComponentModel.DataAnnotations;

namespace ItaLog.Api.ViewModels.Log
{
    public class LogEventViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public DateTime ErrorDate { get; set; }

        [Required]
        public int EnvironmentId { get; set; }

        [Required]
        public int ApiUserId { get; set; }

        [Required]
        public int LevelId { get; set; }

    }
}