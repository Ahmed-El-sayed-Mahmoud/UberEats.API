using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberEats.Domain.Exceptions
{
    public class BadRequestException : Exception
    {
        public string ErrorMessage { get; }

        public BadRequestException(string errorMessage)
            : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
