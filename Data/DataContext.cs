using Microsoft.EntityFrameworkCore;
using Presentation.Entities;

namespace Presentation.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; }
    
    public DbSet<BookingOwnerEntity> BookingOwners { get; set; }
    
    public DbSet<BookingAddressEntity> BookingAddresses { get; set; }
}