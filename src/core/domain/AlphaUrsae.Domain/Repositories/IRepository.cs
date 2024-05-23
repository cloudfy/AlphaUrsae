using AlphaUrsae.Domain.Abstracts;
using System.Linq.Expressions;

namespace AlphaUrsae.Domain.Repositories;

public interface IRepository
{
    Task<T?> FindOneOrNull<T>(
        Expression<Func<T>> predicate, CancellationToken cancellationToken) where T : IAggregateRoot;
    Task<T> FindOne<T>(
        Expression<Func<T>> predicate, CancellationToken cancellationToken) where T : IAggregateRoot;
    Task<IEnumerable<T>> FindMany<T>(
        Expression<Func<T>> predicate, CancellationToken cancellationToken) where T : IAggregateRoot;
}
