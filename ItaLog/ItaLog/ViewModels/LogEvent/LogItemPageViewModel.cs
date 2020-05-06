using ItaLog.Application.ViewModels.Environment;
using ItaLog.Application.ViewModels.Level;
using System;

namespace ItaLog.Application.ViewModels.Log
{
    public class LogItemPageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EventsCount { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Origin { get; set; }


        public LevelViewModel Level { get; set; }
        public EnvironmentViewModel Environment { get; set; }

    }
}