using CLUB.COMMON;

namespace CLUB.API.Infrastructures
{
    /// <summary>
    /// Реализация времени
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        DateTimeOffset IDateTimeProvider.UtcNow => DateTimeOffset.UtcNow;
    }
}



