namespace api.DTO.Stock
{
    public record CreateStockDTO(string Symbol, string CompanyName, decimal Purchase, decimal LastDividend, string Industry, decimal MarketCap);
}
