namespace TaxiApp.Kernel.Exeptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException() : base()
        {
        }

        public InvalidRequestException(string message) : base(message)
        {
        }
    }
}
