using Microsoft.AspNetCore.Authorization;
using Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Presentation.Interfaces;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;
    
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CreateBookingRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _bookingService.CreateBookingAsync(request);
        return result.Success ? Ok() : StatusCode(500, result.Error);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _bookingService.GetBookingsAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _bookingService.GetBookingAsync(id);

        if (!result.Success || result.Result == null)
            return NotFound();
        
        return Ok(result.Result);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateBookingRequest request)
    {
        var result = await _bookingService.UpdateBookingAsync(id, request);
        return result.Success ? Ok() : StatusCode(500, result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _bookingService.DeleteBookingAsync(id);
        return result.Success ? Ok() : StatusCode(500, result.Error);
    }
}