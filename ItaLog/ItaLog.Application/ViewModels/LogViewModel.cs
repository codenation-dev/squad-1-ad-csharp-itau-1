using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Application.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int UserErrorCode { get; set; }


        public int UserId { get; set; }

        public ApiUserViewModel User { get; set; }


        public EnvironmentViewModel Environment { get; set; }

        public LevelViewModel Level { get; set; }
    }
}
