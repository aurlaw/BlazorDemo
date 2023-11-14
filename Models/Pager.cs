using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorDemo.Models
{
    public record Pager(int Page, int PageSize, int TotalItems) 
    {
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
        public bool HasPreviousPage => Page > 1;
        public bool HasNextPage => Page < TotalPages;
    }


    public class PaginatedResult<T> where T : class
    {
        public IList<T> Results {get; private set;}=null!;
        public Pager PageInfo {get; private set;}=null!;

        public PaginatedResult(IList<T> results, Pager info)
        {
            Results = results;
            PageInfo = info;
        }

        public static async Task<PaginatedResult<T>> Create(IQueryable<T> query, int pageNumber, int pageSize) 
        {
            var count = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedResult<T>(items, new Pager(pageNumber, pageSize, count));
        }
    }
}
