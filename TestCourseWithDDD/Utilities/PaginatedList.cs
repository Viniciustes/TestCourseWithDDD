using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TestCourseWithDDD.Utilities
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; }

        public int TotalPages { get; }

        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;

            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public static PaginatedList<T> CreatePaginatedList(IEnumerable<T> source, HttpRequest request)
        {
            const int pageSize = 5;

            int.TryParse(request.Query["page"], out var pageIndex);

            pageIndex = pageIndex > 0 ? pageIndex : 1;

            var enumerable = source as IList<T> ?? source.ToList();

            var count = enumerable.Count();

            var items = enumerable.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}