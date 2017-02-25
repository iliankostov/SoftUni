namespace Interfaces
{
    using System;

    using Enumerables;

    public interface IRent
    {
        IItem RentItem { get; }

        RentState RentState { get; }

        DateTime RentDate { get; }

        DateTime Deadline { get; }

        DateTime ReturnDate { get; }

        decimal RentFine { get; }

        void ReturnItem();
    }
}