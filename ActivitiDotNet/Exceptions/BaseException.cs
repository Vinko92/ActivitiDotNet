using System;

namespace ActivitiDotNet.Exceptions
{
    internal class BaseException : Exception
    {
        private string _message;
        private string _stackTrace;

        public override string Message
        {
            get
            {
                return _message;
            }
        }

        public override string StackTrace
        {
            get
            {
                return _stackTrace;
            }
        }

        public BaseException(string message)
        {
            _message = message;
        }

        public BaseException(string message, string stackTrace)
        {
            _message = message;
            _stackTrace = stackTrace;
        }
    }
}
