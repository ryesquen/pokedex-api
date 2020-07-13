using Common.Collection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Paging
{
    public static class PagingExtension
    {
        public static DataCollection<T> GetPaged<T>(
            this List<T> query,
            int page,
            int take)
        {
            var originalPages = page;

            page--;

            if (page > 0)
                page = page * take;

            var result = new DataCollection<T>
            {
                Items = query.Skip(page).Take(take).ToList(),
                Total = query.Count(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
