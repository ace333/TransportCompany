using System;

namespace TransportCompany.Shared.Application.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string message) : base(message)
        {
        }
    }
}
