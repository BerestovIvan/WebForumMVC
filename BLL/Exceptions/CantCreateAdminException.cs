using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class CantCreateAdminException : Exception
    {
        public CantCreateAdminException() { }
        public CantCreateAdminException(string message) : base(message) { }
        public CantCreateAdminException(string message, Exception innerException) : base(message, innerException)
        { }

        public CantCreateAdminException(string name, object key)
            : base("Admin creation exception")
        {
        }
    }
}
