using System;
using System.Collections.Generic;
using System.Linq;

namespace CQ.Note.Core.Events
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<object>> _eventHandlers;
        private readonly object _obj;

        public EventBus()
        {
            _eventHandlers = new Dictionary<Type, List<object>>();
            _obj = new object();
        }


        public void Subscribe<TEvent>(IEventHandler<TEvent> handler)
            where TEvent : IEvent
        {
            lock (_obj)
            {
                Type eventType = typeof(TEvent);
                if (_eventHandlers.TryGetValue(eventType, out List<object> handers))
                {
                    if (handers == null)
                    {
                        handers = new List<object>();
                    }

                    handers.Add(handers);
                }
                else
                {
                    _eventHandlers[eventType] = new List<object> { handler };
                }
            }
        }



        public void Publish<TEvent>(TEvent @event, Action<TEvent, bool, Exception> callBack)
            where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            if (_eventHandlers.TryGetValue(eventType, out List<object> handers))
            {
                if (handers.Any())
                {
                    try
                    {
                        foreach (var obj in handers)
                        {
                            var hander = obj as IEventHandler<TEvent>;
                            hander.Handler(@event);
                            callBack(@event, true, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        callBack(@event, false, ex);
                    }
                }
            }
        }
    }
}
