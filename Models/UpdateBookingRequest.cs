namespace Presentation.Models;

public class UpdateBookingRequest
{

    public string Id { get; set; } = null!;
    public int? TicketQuantity { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Email { get; set; }
    
    public  string? StreetName { get; set; }
    
    public string? PostalCode { get; set; }
    
    public string? City { get; set; }
}