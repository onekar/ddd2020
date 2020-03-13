using System;

namespace Marketplace.Framework
{
    public class CurrencyMismatchException : Exception
    {
        public CurrencyMismatchException(string message) : base(message) { }
    }
}
