
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace gerdisc.Infrastructure.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime? Parse(this string? dateString) =>
            dateString is null ? null : DateTime.TryParse(dateString, out var date) ? date.ToUniversalTime() : null;
    }
}