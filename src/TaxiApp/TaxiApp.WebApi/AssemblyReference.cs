using System.Reflection;

namespace TaxiApp.WebApi
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
