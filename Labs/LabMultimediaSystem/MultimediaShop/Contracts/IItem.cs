namespace MultimediaShop.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IItem
    {
        string Id
        {
            get;
        }

        string Title
        {
            get;
        }

        decimal Price
        {
            get;
        }

        List<string> Genres
        {
            get;
        }
    }
}