namespace Presentation.Models;

public class Booking
{
    public string Id { get; set; } = null!;
    
    public string EventId { get; set; } = null!;
    
    public DateTime BookingDate { get; set; }
    
    public int TicketQuantity { get; set; } = 1;
    
    public string? FirstName { get; set; } 
    
    public string? LastName { get; set; } = null!;
    
    public string? Email { get; set; } 
    
    public string? StreetName { get; set; } 
    
    public string? PostalCode { get; set; } 
    
    public string? City { get; set; } 
}