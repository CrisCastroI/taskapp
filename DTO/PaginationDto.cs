namespace Class12.DTO
{
    public class PaginationDto
    {
        int? TotalCount;
        int? PageSize;
        int? CurrentPage;
        int? TotalPages;
        string? HasNext;
        string? HasPrevious;

        public PaginationDto(int totalCount, int pageSize, int currentPage, int totalPages, string hasNext, string hasPrevious)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            HasNext = hasNext;
            HasPrevious = hasPrevious;
        }

        public PaginationDto(int pageSize, int currentPage)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
        }
    }
}
