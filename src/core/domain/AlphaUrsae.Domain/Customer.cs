using AlphaUrsae.Domain.Abstracts;
using AlphaUrsae.Domain.Identities;

namespace AlphaUrsae.Domain;

public class Customer : IAggregateRoot
{
    public CustomerId Id { get; init; } = default!;
    public string Name { get; init; } = default!;
}