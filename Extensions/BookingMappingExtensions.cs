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

    public static Booking ToModel(this BookingEntity entity)
    {
        return new Booking
        {
            Id = entity.Id,
            EventId = entity.EventId,
            TicketQuantity = entity.TicketQuantity,
            BookingDate = entity.BookingDate,
            FirstName = entity.BookingOwner?.FirstName,
            LastName = entity.BookingOwner?.LastName,
            Email = entity.BookingOwner?.Email,
            StreetName = entity.BookingOwner?.Address?.StreetName,
            PostalCode = entity.BookingOwner?.Address?.PostalCode,
            City = entity.BookingOwner?.Address?.City
        };
    }

    public static void Update(this BookingEntity entity, UpdateBookingRequest request)
    {
        if (request.TicketQuantity.HasValue)
            entity.TicketQuantity = request.TicketQuantity.Value;

        if (entity.BookingOwner != null)
        {
            if (!string.IsNullOrWhiteSpace(request.FirstName))
                entity.BookingOwner.FirstName = request.FirstName;

            if (!string.IsNullOrWhiteSpace(request.LastName))
                entity.BookingOwner.LastName = request.LastName;

            if (!string.IsNullOrWhiteSpace(request.Email))
                entity.BookingOwner.Email = request.Email;

            if (entity.BookingOwner.Address != null)
            {
                if (!string.IsNullOrWhiteSpace(request.StreetName))
                    entity.BookingOwner.Address.StreetName = request.StreetName;

                if (!string.IsNullOrWhiteSpace(request.PostalCode))
                    entity.BookingOwner.Address.PostalCode = request.PostalCode;

                if (!string.IsNullOrWhiteSpace(request.City))
                    entity.BookingOwner.Address.City = request.City;
            }
        }
    }
}