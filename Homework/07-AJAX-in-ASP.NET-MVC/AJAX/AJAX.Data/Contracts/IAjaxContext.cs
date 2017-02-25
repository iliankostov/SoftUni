namespace AJAX.Data.Contracts
{
    using System.Data.Entity;

    using AJAX.Models;

    public interface IAjaxContext
    {
        IDbSet<Town> Towns { get; }
    }
}