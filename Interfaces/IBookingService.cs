using Presentation.Models;

namespace Presentation.Interfaces;

public interface IBookingService
{
    Task<BookingResult> CreateBookingAsync(CreateBookingRequest request);
    
    Task<BookingResult<IEnumerable<Booking>>> GetBookingsAsync();

    Task<BookingResult<Booking?>> GetBookingAsync(string bookingId);

    Task<BookingResult> UpdateBookingAsync(string id, UpdateBookingRequest request);

    Task<BookingResult> DeleteBookingAsync(string bookingId);
}