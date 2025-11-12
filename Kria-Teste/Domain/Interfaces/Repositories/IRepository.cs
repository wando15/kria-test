using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : AggregateRoot
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<List<TEntity>> GetAllAsync();
    }
}

