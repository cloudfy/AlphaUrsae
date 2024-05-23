using AlphaUrsae.Domain.Abstracts;
using System.Linq.Expressions;

namespace AlphaUrsae.Domain.Repositories;

public class GenericRepository : IRepository
{
    private readonly DatabaseContext _context;

    internal GenericRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<T>> FindMany<T>(Expression<Func<T>> predicate, CancellationToken cancellationToken) where T : IAggregateRoot
    {
        throw new NotImplementedException();
    }

    public Task<T> FindOne<T>(Expression<Func<T>> predicate, CancellationToken cancellationToken) where T : IAggregateRoot
    {
        throw new NotImplementedException();
    }

    public Task<T?> FindOneOrNull<T>(Expression<Func<T>> predicate, CancellationToken cancellationToken) where T : IAggregateRoot
    {
        throw new NotImplementedException();
    }
}
