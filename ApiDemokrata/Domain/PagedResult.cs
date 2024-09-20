namespace ApiDemokrata.Domain
{
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; }
    }
}
