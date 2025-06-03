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
}