﻿using System.Reflection;

namespace TaxiApp.Persistence
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}