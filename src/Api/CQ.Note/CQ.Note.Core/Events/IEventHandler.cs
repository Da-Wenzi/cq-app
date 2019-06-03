namespace CQ.Note.Core.Events
{

    public interface IEventHandler<TEvent>
        where TEvent : IEvent
    {
        void Handler(TEvent @event);
    }
}
