namespace CleanArchitecture.Template.Domain.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> GetAll(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        void Add(T entity);
        void Add(List<T> entities);
        Task AddAsync(T entity);
        Task AddAsync(List<T> entities);
        void Delete(T entity);
        void Update(T entity);
    }
}
