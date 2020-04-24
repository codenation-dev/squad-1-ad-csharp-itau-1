using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.ViewModels
{
    public class LogItemPageViewModel
    {
        public int IdLog { get; set; }
        public string Title { get; set; }
        public int EventsCount { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Origin { get; set; }


        public LevelViewModel Level { get; set; }
        public EnvironmentViewModel Environment { get; set; }
    }
}