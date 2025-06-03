using Presentation.Extensions;
using Presentation.Interfaces;
using Presentation.Models;

namespace Presentation.Services;

public class BookingService(IBookingRepository repository) : IBookingService
{
    private readonly IBookingRepository _repository = repository;
    public async Task<BookingResult> CreateBookingAsync(CreateBookingRequest request)
    {
        var bookingEntity = request.MapToEntity();
        
        var result = await _repository.AddAsync(bookingEntity);
        return result.Success
            ? new BookingResult { Success = true }
            : new BookingResult { Success = false, Error = result.Error };
    }
}