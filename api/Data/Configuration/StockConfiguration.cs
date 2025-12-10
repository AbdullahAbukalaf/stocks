using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            // Map to table name "Stocks"
            builder.ToTable("Stocks");

            // Primary key
            builder.HasKey(s => s.Id);

            // Property configurations
            builder.Property(s => s.Symbol)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.CompanyName)
                .HasMaxLength(200)
                .IsRequired();

            // Ensure decimal precision explicitly on both fields
            builder.Property(s => s.Purchase)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.LastDividend)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Industry)
                .HasMaxLength(100);

            builder.Property(s => s.MarketCap);

            // Default value for soft-delete flag
            builder.Property(s => s.IsDeleted)
                .HasDefaultValue(false);

            // Index for quick symbol lookup
            builder.HasIndex(s => s.Symbol).IsUnique();

            builder.HasIndex(s => s.CompanyName);

            // Relationship configuration (explicit)
            builder.HasMany(s => s.Comments)
                .WithOne(c => c.Stock)
                .HasForeignKey(c => c.StockId)
                .OnDelete(DeleteBehavior.Cascade);

            // Global query filter for soft delete
            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}