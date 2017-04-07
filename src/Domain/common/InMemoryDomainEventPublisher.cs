using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SimpleBankApplication.Domain.common
{
    internal class InMemoryDomainEventPublisher : IDomainEventPublisher
    {
        private readonly ConcurrentQueue<DomainEvent> _eventQueue;
        private readonly ConcurrentDictionary<Type, ConcurrentBag<Action<DomainEvent>>> _subscribers;

        public InMemoryDomainEventPublisher()
        {
            _eventQueue = new ConcurrentQueue<DomainEvent>();
            _subscribers = new ConcurrentDictionary<Type, ConcurrentBag<Action<DomainEvent>>>();

            Task.Factory.StartNew(DoInfiniteDequeueAndNotifySubscribers);
        }


        public void Publish(DomainEvent @event)
        {
            // streamId, expectedVersion, payload
            Console.WriteLine("Eventbroker Publish");
            _eventQueue.Enqueue(@event);
        }

        public void SubscribeOn<T>(Action<T> eventHandle) where T : DomainEvent
        {
            var domainEventType = typeof(T);

            ConcurrentBag<Action<DomainEvent>> subscribersList;
            if (!_subscribers.TryGetValue(domainEventType, out subscribersList))
            {
                subscribersList = new ConcurrentBag<Action<DomainEvent>>();
                _subscribers.TryAdd(domainEventType, subscribersList);
            }
            subscribersList.Add((@event) => eventHandle((T)@event));
        }


        private void DoInfiniteDequeueAndNotifySubscribers()
        {
            while (true)
            {
                try
                {
                    DomainEvent newDomainEvent;
                    if (_eventQueue.TryDequeue(out newDomainEvent))
                    {
                        var domainEventType = newDomainEvent.GetType();
                        ConcurrentBag<Action<DomainEvent>> allSubscribers;
                        if (_subscribers.TryGetValue(domainEventType, out allSubscribers))
                        {
                            foreach (var handle in allSubscribers)
                            {
                                Task.Factory.StartNew(() => { handle(newDomainEvent); });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }
    }
}