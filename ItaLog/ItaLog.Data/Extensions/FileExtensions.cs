using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ItaLog.Data.Extensions
{
    public static class FileExtensions
    {
        public static string ToCsv<T>(this IEnumerable<T> data, bool header = false)
        {
            var formatCSV = new StringBuilder();

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            if (header)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    formatCSV.Append(prop.DisplayName);
                    formatCSV.Append(";");
                }
                formatCSV.AppendLine();
            }            

            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    formatCSV.Append(prop.Converter.ConvertToString( prop.GetValue(item)));
                    formatCSV.Append(";");
                }

                formatCSV.AppendLine();
            }

            return formatCSV.ToString();
        }
    }
}
