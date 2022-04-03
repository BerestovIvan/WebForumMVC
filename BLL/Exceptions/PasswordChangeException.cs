using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class PasswordChangeException : Exception
    {
        public PasswordChangeException() { }
        public PasswordChangeException(string message) : base(message) { }
        public PasswordChangeException(string message, Exception innerException) : base(message, innerException)
        { }

        public PasswordChangeException(string name, object key)
            : base("Password change exception")
        {
        }
    }
}
