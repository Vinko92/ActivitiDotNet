using System;

namespace ActivitiDotNet.Exceptions
{
    internal class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, string stackTrace) : base(message, stackTrace) { }
    }
}
