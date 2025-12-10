using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Table
            builder.ToTable("Comments");

            // Key
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(c => c.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.Content)
                .HasMaxLength(4000)
                .IsRequired();

            // Use server-side UTC default for CreatedAt
            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(c => c.StockId)
                .IsRequired();

            // Indexes
            builder.HasIndex(c => c.StockId);

            // Relationship (explicit)
            builder.HasOne(c => c.Stock)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.StockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}