namespace Infrastructure.Pagination;

public class PaginatedResult <T> where T : class
{
    
    //pagination class
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public List<T> Items { get; set; }
    
    public PaginatedResult(int page, int pageSize, int totalCount, int totalPages, List<T> items)
    {
        Page = page;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = totalPages;
        Items = items;
    }

    public PaginatedResult()
    {
        
    }
    
}