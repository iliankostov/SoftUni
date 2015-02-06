namespace MultimediaShop.Contracts
{
    using System;
    using MultimediaShop.Models;

    public interface IRenntable
    {
        Item RentItem
        {
            get;
        }

        RentStatus RentState
        {
            get;
        }

        decimal RentFine
        {
            get;
        }       
    }
}