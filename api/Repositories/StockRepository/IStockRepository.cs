using api.DTO.Stock;
using api.Models;

namespace api.Repositories.StockRepository
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStocksAsync();
        Task<Stock?> GetStockAsync(int id, CancellationToken ct);
        Task CreateStockAsync(Stock stock, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct = default);
        Task UpdateStockAsync(Stock stock, CancellationToken ct);
        Task SoftDeleteAsync(Stock stock, CancellationToken ct);
    }
}
