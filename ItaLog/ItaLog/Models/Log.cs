using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItaLog.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        public int Event { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public bool Archive { get; set; }

        public DateTime Date { get; set; }

        public string User { get; set; }

        public string Origin { get; set; }

        public int Environment { get; set; }

        public int Level { get; set; }
    }
}
