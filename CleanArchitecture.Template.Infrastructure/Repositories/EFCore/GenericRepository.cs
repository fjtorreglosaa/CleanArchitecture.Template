using CleanArchitecture.Template.Domain.Abstractions.Repositories;
using CleanArchitecture.Template.Infrastructure.Contexts;
using CleanArchitecture.Template.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Repositories.EFCore
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Add(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll(CancellationToken cancellationToken = default)
        {
            return _context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(id, cancellationToken);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
