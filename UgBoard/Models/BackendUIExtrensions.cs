using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public static class BackendUIExtrensions
    {
        public static QueryResult<TResponse> AsResult<TResponse>(this IQuery<TResponse> query)
        {
            return new QueryResult<TResponse>(query);
        }
    }
}
