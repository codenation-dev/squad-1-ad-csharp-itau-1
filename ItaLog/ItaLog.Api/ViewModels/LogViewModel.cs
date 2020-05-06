using System.Collections.Generic;

namespace ItaLog.Api.ViewModels
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Origin { get; set; }
        public bool Archived { get; set; }

        public int EnvironmentId { get; set; }
        public EnvironmentViewModel Environment { get; set; }


        public int ApiUserId { get; set; }
        public UserViewModel ApiUser { get; set; }

        public int LevelId { get; set; }
        public LevelViewModel Level { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
