namespace BankingSolution.Application.DTO.Account;

public record PagedResponse<AccountDto>
{
    public List<AccountDto> Items { get; set; } = new();
    public int CurrentPage { get; set; }
    public int PageSize { get; set; } 
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasNextPage => CurrentPage < TotalPages;
}