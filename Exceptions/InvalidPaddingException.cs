using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperations.Exceptions
{
    internal class InvalidPaddingException : Exception
    {
        public InvalidPaddingException() : base($"Invalid padding value.")
        {
        }
    }
}
