namespace Interfaces
{
    using System.Collections.Generic;

    public interface IItem
    {
        string Id { get; }

        string Title { get; }

        decimal Price { get; }

        string Genre { get; }

        IList<string> Genres { get; }
    }
}