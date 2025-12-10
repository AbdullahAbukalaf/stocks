using System.ComponentModel.DataAnnotations.Schema;

namespace api.DTO.Stock
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDividend { get; set; }
        public string Industry { get; set; } = string.Empty;
        public decimal MarketCap { get; set; }
    }
}
