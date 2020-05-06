using ItaLog.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItaLog.Domain.Models
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
