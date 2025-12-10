namespace api.DTO.Stock
{
    public record UpdateStockDTO(string? Symbol, string? CompanyName, decimal? Purchase, decimal? LastDividend, string? Industry, decimal? MarketCap);
}
