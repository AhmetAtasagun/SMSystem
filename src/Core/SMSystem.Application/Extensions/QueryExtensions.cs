namespace SMSystem.Application.Extensions
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNo, int pageCount)
        {
            return query.Skip((pageNo - 1) * pageCount).Take(pageCount);
        }
    }
}
