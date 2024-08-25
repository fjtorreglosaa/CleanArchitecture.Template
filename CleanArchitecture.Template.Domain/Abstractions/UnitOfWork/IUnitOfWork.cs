namespace CleanArchitecture.Template.Domain.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
