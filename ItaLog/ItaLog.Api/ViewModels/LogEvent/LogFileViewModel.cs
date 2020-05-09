using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Api.ViewModels.Log
{
    public class LogFileViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EventsCount { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Origin { get; set; }


        public string Level { get; set; }
        public string Environment { get; set; }
    }
}
