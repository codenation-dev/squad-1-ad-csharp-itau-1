using System;
using System.Diagnostics.CodeAnalysis;

namespace ItaLog.Api.ViewModels.Environment
{
    public class EnvironmentViewModel : IComparable<EnvironmentViewModel>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int CompareTo([AllowNull] EnvironmentViewModel other)
        {
            return Description.CompareTo(other.Description);
        }
    }
}
