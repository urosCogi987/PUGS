namespace TaxiApp.Kernel.Exeptions
{
    public sealed class ForbiddenOperationException : Exception
    {
        public ForbiddenOperationException() : base()
        {
        }

        public ForbiddenOperationException(string message) : base(message)
        {
        }
    }
}
