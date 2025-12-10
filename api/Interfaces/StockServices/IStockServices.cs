using api.DTO.Stock;

namespace api.Interfaces.StockServices
{
    public interface IStockServices
    {
        public Task<List<StockDTO>> GetStocks();
        public Task<StockDTO?> GetStock(int id, CancellationToken ct); 
        public Task<StockDTO> CreateStock(CreateStockDTO stockDto, CancellationToken ct);
        public Task<StockDTO?> UpdateStock(int id, UpdateStockDTO stockDto, CancellationToken ct);
        public Task<bool> SoftDeleteStock(int id, CancellationToken ct);

    }
}
