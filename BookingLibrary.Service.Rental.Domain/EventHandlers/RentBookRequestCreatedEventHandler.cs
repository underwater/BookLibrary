using System;
using System.Threading.Tasks;
using BookingLibrary.Domain.Core;
using BookingLibrary.Service.Rental.Domain.Events;
using BookingLibrary.Service.Rental.Domain.DataAccessors;
using BookingLibrary.Domain.Core.Messaging;

namespace BookingLibrary.Service.Rental.Domain
{
    public class RentBookRequestCreatedEventHandler : IEventHandler<RentBookRequestCreatedEvent>
    {
        private IRentalReportDataAccessor _reportDataAccessor = null;
        private IEventPublisher _eventPublisher = null;

        public RentBookRequestCreatedEventHandler(IRentalReportDataAccessor reportDataAccessor, IEventPublisher eventPublisher)
        {
            _reportDataAccessor = reportDataAccessor;
            _eventPublisher = eventPublisher;
        }

        public void Handle(RentBookRequestCreatedEvent evt)
        {
            try
            {
                _reportDataAccessor.CreateRentBookRequest(evt.BookInventoryId, evt.BookName, evt.ISBN, evt.AggregateId, evt.Name, evt.RentDate);
                _reportDataAccessor.Commit();

                _eventPublisher.Publish(new RentBookRequestAcceptedEvent
                {
                    AggregateId = evt.BookInventoryId,
                    CommandUniqueId = evt.CommandUniqueId,
                    Notes = $"Rent by {evt.Name.FirstName} {evt.Name.LastName} at {evt.RentDate.ToString("yyyy-MM-dd HH:mm:ss")}",
                    CustomerId = evt.AggregateId
                });
            }
            catch
            {

            }
        }

        public Task HandleAsync(RentBookRequestCreatedEvent evt)
        {
            return Task.Factory.StartNew(() =>
            {
                Handle(evt);
            });
        }
    }
}