using ItaLog.Api.ViewModels.Environment;
using ItaLog.Api.ViewModels.Level;
using System;

namespace ItaLog.Api.ViewModels.Log
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