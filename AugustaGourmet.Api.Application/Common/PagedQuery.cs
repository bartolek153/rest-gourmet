
using AugustaGourmet.Api.Application.Contracts.Common;

using MediatR;

namespace AugustaGourmet.Api.Application.Common;

public class PagedQuery<TResult> : IRequest<PagedList<TResult>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? OrderByColumn { get; set; }
    public bool? OrderByDescending { get; set; }
    public string? Filter { get; set; }

    public PagedQuery(int page = 1, int pageSize = 10, string? filter = null)
    {
        Page = page;
        PageSize = pageSize;
        Filter = filter;
    }
};