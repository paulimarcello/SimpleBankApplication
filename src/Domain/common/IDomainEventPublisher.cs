using System;

namespace SimpleBankApplication.Domain.common
{
    internal interface IDomainEventPublisher
    {
        void Publish(DomainEvent @event);
        void SubscribeOn<T>(Action<T> eventHandle) where T : DomainEvent;
    }
}