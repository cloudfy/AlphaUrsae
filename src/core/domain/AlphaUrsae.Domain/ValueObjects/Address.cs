namespace AlphaUrsae.Domain.ValueObjects;

public record Address
    (string Street1, string? Street2, string City, string? State, string ZipCode, string Country)
{

}