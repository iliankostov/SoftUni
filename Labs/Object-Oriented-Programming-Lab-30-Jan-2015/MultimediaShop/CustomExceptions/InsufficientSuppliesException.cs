namespace CustomExceptions
{
    using System;

    public class InsufficientSuppliesException : Exception
    {
        public InsufficientSuppliesException()
            : base(string.Format(
            "Insufficient item quantity!\r\n" +
            "The item you have requested is out of stock."))
        {
        }
    }
}