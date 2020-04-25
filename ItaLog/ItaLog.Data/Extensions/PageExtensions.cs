using ItaLog.Domain.Models;
using System;
using System.Linq;

namespace ItaLog.Data.Extensions
{
    public static class PageExtensions
    {
        public static Page<T> ToPage<T>(this IQueryable<T> query, int pageNumber = 1, int pageLength = 20)
        {
            int totalItens = query.Count();
            int totalPages = (int)Math.Ceiling(totalItens / (double)pageLength);

            return new Page<T>()
            {
                Total = totalItens,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                PageLength = pageLength,
                Result = query
                    .Skip(pageLength * (pageNumber - 1))
                    .Take(pageLength)
                    .ToList()
            };
        }
    }
}
