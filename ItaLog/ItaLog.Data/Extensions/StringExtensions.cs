using System;
using System.IO;
using System.Text;

namespace ItaLog.Data.Extensions
{
    public static class StringExtensions
    {
        public static MemoryStream ToMemoryStream(this string data)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(data));
        }
    }
}
