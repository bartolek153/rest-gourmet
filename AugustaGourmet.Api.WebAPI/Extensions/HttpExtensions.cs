
namespace AugustaGourmet.Api.WebAPI.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response,
                                           string key,
                                           int page,
                                           int perPage,
                                           int total)
    {
        int endIndex = Math.Min(page + perPage - 1, total - 1);
        string contentRange = $"{key} {page}-{endIndex}/{total}";

        response.Headers.Append("Content-Range", contentRange);
        response.Headers.Append("Access-Control-Expose-Headers", "Content-Range");
    }

    public static void AddPaginationHeader(this HttpResponse response,
                                           int page,
                                           int perPage,
                                           int total)
    {
        int endIndex = Math.Min(page + perPage - 1, total - 1);
        string contentRange = $"{page}-{endIndex}/{total}";

        response.Headers.Append("Content-Range", contentRange);
        response.Headers.Append("Access-Control-Expose-Headers", "Content-Range");
    }
}