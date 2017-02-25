namespace Interfaces
{
    using System;

    public interface ISale
    {
        IItem SaleItem { get; }

        DateTime SaleDate { get; }
    }
}