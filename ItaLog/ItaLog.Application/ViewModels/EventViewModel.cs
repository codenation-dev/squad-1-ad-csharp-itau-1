using System;

namespace ItaLog.Application.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public DateTime ErrorDate { get; set; }
        public string Origin { get; set; }
        public bool Archived { get; set; }
    }
}
