namespace UniLogger.Contracts
{
    public interface ILayout
    {
        string Format(IEvent @event);
    }
}