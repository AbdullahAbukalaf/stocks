using api.DTO.Stock;
using api.Models;
using api.Repositories.StockRepository;
using AutoMapper;

namespace api.Interfaces.StockServices
{
    public class StockServices : IStockServices
    {
        private readonly IStockRepository stockRepository;
        private readonly IMapper mapper;
        public StockServices(IStockRepository stockRepository, IMapper mapper)
        {
            this.stockRepository = stockRepository;
            this.mapper = mapper;
        }
        public async Task<StockDTO> CreateStock(CreateStockDTO stockDto, CancellationToken ct)
        {
            var stock  = mapper.Map<Stock>(stockDto);
            await stockRepository.CreateStockAsync(stock, ct);
            await stockRepository.SaveChangesAsync(ct);
            return mapper.Map<StockDTO>(stock);
        }

        public async Task<StockDTO?> GetStock(int id, CancellationToken ct)
        {
            var stock = await stockRepository.GetStockAsync(id, ct);
            return stock is null ? null : mapper.Map<StockDTO>(stock);
        }

        public async Task<List<StockDTO>> GetStocks()
        {
           var stocks = await stockRepository.GetStocksAsync();
           return mapper.Map<List<StockDTO>>(stocks);
        }


        public async Task<StockDTO?> UpdateStock(int id, UpdateStockDTO stockDto, CancellationToken ct)
        {
            var stock = await stockRepository.GetStockAsync(id, ct);
            if (stock is null) return null;
            if (stockDto.Symbol is not null) stock.Symbol = stockDto.Symbol;
            if (stockDto.CompanyName is not null) stock.CompanyName = stockDto.CompanyName;
            if (stockDto.Purchase is not null) stock.Purchase = stockDto.Purchase.Value;
            if (stockDto.LastDividend is not null) stock.LastDividend = stockDto.LastDividend.Value;
            if (stockDto.Industry is not null) stock.Industry = stockDto.Industry;
            if (stockDto.MarketCap is not null) stock.MarketCap = stockDto.MarketCap.Value;
            await stockRepository.UpdateStockAsync(stock, ct);
            await stockRepository.SaveChangesAsync(ct);
            return mapper.Map<StockDTO>(stock);

        }

        public async Task<bool> SoftDeleteStock(int id, CancellationToken ct)
        {
            var stock =  await stockRepository.GetStockAsync(id, ct);
            if (stock is null) return false;
            await stockRepository.SoftDeleteAsync(stock, ct);
            await stockRepository.SaveChangesAsync(ct);
            return true;
        }

    }
}
