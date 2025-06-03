using Presentation.Entities;
using Presentation.Models;

namespace Presentation.Extensions;

public static class BookingMappingExtensions
{
    public static BookingEntity MapToEntity(this CreateBookingRequest request)
    {
        return new BookingEntity
        {
            EventId = request.EventId,
            BookingDate = DateTime.Now,
            TicketQuantity = request.TicketQuantity,
            BookingOwner = new BookingOwnerEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = new BookingAddressEntity
                {
                    StreetName = request.StreetName,
                    PostalCode = request.PostalCode,
                    City = request.City
                }
            }
        };
    }
}