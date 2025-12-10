using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.StockRepository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task CreateStockAsync(Stock stock, CancellationToken ct)
        { 
            await _context.Stocks.AddAsync(stock, ct);
            // do not SaveChanges here; service calls SaveChangesAs
        }


        public async Task<Stock?> GetStockAsync(int id, CancellationToken ct = default)
        => await _context.Stocks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, ct);

        public async Task<List<Stock>> GetStocksAsync()
        => await _context.Stocks.AsNoTracking().ToListAsync();

        public async Task SaveChangesAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);

        public Task UpdateStockAsync(Stock stock, CancellationToken ct = default)
        {
            _context.Stocks.Update(stock);
            return Task.CompletedTask;
        }

        public Task SoftDeleteAsync(Stock stock, CancellationToken ct)
        {
            stock.IsDeleted = true;
            stock.DeletedAt = DateTime.UtcNow;
            _context.Stocks.Update(stock);
            return Task.CompletedTask;
        }

    }
}
