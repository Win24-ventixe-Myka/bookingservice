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

    public async Task<BookingResult<IEnumerable<Booking>>> GetBookingsAsync()
    {
        var result = await _repository.GetAllAsync();

        if (!result.Success || result.Result == null)
        {
            return new BookingResult<IEnumerable<Booking>> { Success = false, Error = result.Error };
        }
        
        return new BookingResult<IEnumerable<Booking>> { Success = true, 
            Result = result.Result.Select(x => x.ToModel()).ToList() };
    }

    public async Task<BookingResult<Booking?>> GetBookingAsync(string bookingId)
    {
        var result = await _repository.GetAsync(x => x.Id == bookingId);

        if (result.Success && result.Result != null)
        {
            return new BookingResult<Booking?> { Success = true, Result = result.Result.ToModel() };
        }

        return new BookingResult<Booking?> { Success = false, Error = "Booking Not Found" };
    }

    public async Task<BookingResult> UpdateBookingAsync(string id, UpdateBookingRequest request)
    {
        try
        {
            var existingBookingResult = await _repository.GetAsync(x => x.Id == id);
            if (!existingBookingResult.Success || existingBookingResult.Result == null)
                return new BookingResult { Success = false, Error = "Booking Not Found" };

            var existingBooking = existingBookingResult.Result;
            existingBooking.Update(request);

            var updateResult = await _repository.UpdateAsync(existingBooking);
            return updateResult.Success
                ? new BookingResult { Success = true }
                : new BookingResult { Success = false, Error = updateResult.Error };
        }
        catch (Exception ex)
        {
            return new BookingResult { Success = false, Error = ex.Message };
        }
    }

    public async Task<BookingResult> DeleteBookingAsync(string bookingId)
    {
        try
        {
            var existingBookingResult = await _repository.GetAsync(x => x.Id == bookingId);
            if (!existingBookingResult.Success || existingBookingResult.Result == null)
                return new BookingResult { Success = false, Error = "Booking Not Found" };

            var deleteResult = await _repository.DeleteAsync(existingBookingResult.Result);
            return deleteResult.Success
                ? new BookingResult { Success = true }
                : new BookingResult { Success = false, Error = deleteResult.Error };
        }
        catch (Exception ex)
        {
            return new BookingResult { Success = false, Error = ex.Message };
        }
    }
    }
