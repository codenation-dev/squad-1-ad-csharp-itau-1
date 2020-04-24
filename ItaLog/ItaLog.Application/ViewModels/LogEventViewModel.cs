using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.ViewModels
{
    public class LogEventViewModel
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Origin { get; set; }
        public DateTime ErrorDate { get; set; }
        public int EnvironmentId { get; set; }
        public int ApiUserId { get; set; }
        public int LevelId { get; set; }

    }
}