using System;
using System.Runtime.Serialization;

namespace ItaLog.Domain.Exceptions
{
    [Serializable]
    public class ForeignKeyNotFoundException : Exception
    {
        public string NameFieldForeignKey { get; set; }
        public ForeignKeyNotFoundException()
        {
        }

        public ForeignKeyNotFoundException(string nameFieldForeignKey, string valueFK)
            : this($"Foriegn Key '{nameFieldForeignKey}' with value '{valueFK}' not found.")
        {
            NameFieldForeignKey = nameFieldForeignKey;
        }

        public ForeignKeyNotFoundException(string message)
            : base(message)
        {
        }

        public ForeignKeyNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ForeignKeyNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
