namespace AlphaUrsae.Extensions;

public static class DateTimeExtensions
{
    public static DateOnly AsDateOnly(this DateTime date)
    {
        return DateOnly.FromDateTime(date);
    }
}