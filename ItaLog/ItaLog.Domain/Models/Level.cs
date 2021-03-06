﻿using ItaLog.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ItaLog.Domain.Models
{
    public class Level : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<Log> Logs { get; set; }

        
    }
}
