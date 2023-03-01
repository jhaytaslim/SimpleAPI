
using System;
using SimpleAPI.Filters;

namespace SimpleAPI.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
