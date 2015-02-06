namespace MultimediaShop.Contracts
{
    using System;
    using MultimediaShop.Models;

    public interface ISellable
    {
        Item SaleItem
        {
            get;
        }

        DateTime SaleDate
        {
            get;
        }
    }
}