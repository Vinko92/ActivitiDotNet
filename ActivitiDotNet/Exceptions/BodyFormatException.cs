namespace ActivitiDotNet.Exceptions
{
    internal class BodyFormatException : BaseException
    {
        public BodyFormatException(string message) : base(message) { }

        public BodyFormatException(string message, string stackTrace) : base(message, stackTrace) { }

    }
}
