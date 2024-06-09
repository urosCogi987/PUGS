namespace TaxiApp.Kernel.Exeptions
{
    public sealed class InvalidRequestException : Exception
    {
        public InvalidRequestException() : base()
        {
        }

        public InvalidRequestException(string message) : base(message)
        {
        }
    }
}
