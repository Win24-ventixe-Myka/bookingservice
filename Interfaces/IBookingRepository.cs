using System.Linq.Expressions;
using Presentation.Entities;
using Presentation.Models;

namespace Presentation.Interfaces;

public interface IBookingRepository : IBaseRepository<BookingEntity>
{
    new Task<RepositoryResult<IEnumerable<BookingEntity>>> GetAllAsync();

    new Task<RepositoryResult<BookingEntity?>> GetAsync(Expression<Func<BookingEntity, bool>> expression);
}