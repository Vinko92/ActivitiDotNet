using System;

namespace ActivitiDotNet.Exceptions
{
    internal class ActivitiWebException : BaseException
    {
        public string StatusCode { get; set; }

        public ActivitiWebException(string message) : base(message) { }

        public ActivitiWebException(string message, string stackTrace) : base(message, stackTrace) { }
    }
}
