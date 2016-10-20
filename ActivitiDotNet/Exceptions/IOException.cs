namespace ActivitiDotNet.Exceptions
{
    internal class IOException : BaseException
    {
        public IOException(string message) : base(message) { }

        public IOException(string message, string stackTrace) : base(message, stackTrace) { }

    }
}
