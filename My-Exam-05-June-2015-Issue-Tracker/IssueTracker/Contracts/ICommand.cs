namespace IssueTracker.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Action { get; }

        IDictionary<string, string> Parameters { get; }
    }
}