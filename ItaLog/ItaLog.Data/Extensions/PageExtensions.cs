using ItaLog.Domain.Models;
using System;
using System.Linq;

namespace ItaLog.Data.Extensions
{
    public static class PageExtensions
    {
        public static Page<T> ToPage<T>(this IQueryable<T> query, PageFilter pageFilter)
        {
            int totalItens = query.Count();
            int totalPages = (int)Math.Ceiling(totalItens / (double)pageFilter.PageLength);

            return new Page<T>()
            {
                Total = totalItens,
                TotalPages = totalPages,
                PageNumber = pageFilter.PageNumber,
                PageLength = pageFilter.PageLength,
                Results = query
                    .Skip(pageFilter.PageLength * (pageFilter.PageNumber - 1))
                    .Take(pageFilter.PageLength)
                    .ToList()
            };
        }
    }
}
