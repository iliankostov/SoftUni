namespace UniLogger.Contracts
{
    public interface IAppender
    {
        ILayout Layout
        {
            get;
            set;
        }

        void Append(IEvent @event);
    }
}