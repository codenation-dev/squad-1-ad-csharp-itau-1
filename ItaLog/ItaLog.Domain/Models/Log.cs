using ItaLog.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace ItaLog.Domain.Models
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int UserErrorCode { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public int ApiUserId { get; set; }
        public ApiUser ApiUser { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
