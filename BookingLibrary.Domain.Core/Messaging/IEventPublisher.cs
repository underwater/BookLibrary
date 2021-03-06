using System;

namespace BookingLibrary.Domain.Core.Messaging
{
    public interface IEventPublisher : IDisposable
    {
        void Publish<T>(T domainEvent) where T: DomainEvent;
    }
}