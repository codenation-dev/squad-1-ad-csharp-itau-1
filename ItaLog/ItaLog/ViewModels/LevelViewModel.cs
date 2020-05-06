using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ItaLog.Application.ViewModels
{
    public class LevelViewModel : IComparable<LevelViewModel>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int CompareTo([AllowNull] LevelViewModel other)
        {
            return Description.CompareTo(other.Description);
        }
    }
    
}
