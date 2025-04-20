using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Domain.Exceptions
{
    public static class IdentityException
    {
        public class TokenException : DomainException
        {
            public TokenException(string message)
                : base("Token Exception", message)
            {
            }
        }
    }
}
