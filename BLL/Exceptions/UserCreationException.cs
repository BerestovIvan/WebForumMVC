using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException() { }
        public UserCreationException(string message) : base(message) { }
        public UserCreationException(string message, Exception innerException) : base(message, innerException)
        { }

        public UserCreationException(string name, object key)
            : base("User creation exception")
        {
        }
    }
}
