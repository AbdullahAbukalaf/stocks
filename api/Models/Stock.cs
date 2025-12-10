using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDividend { get; set; }
        public string Industry { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal MarketCap { get; set; }
        public bool IsDeleted { get; set; } = false;
        // DeletedAt should be nullable so it's empty until the row is actually deleted/soft-deleted
        public DateTime? DeletedAt { get; set; } = null;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
