using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Db.Models
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> entityTypeBuilder)
        {
            entityTypeBuilder.HasOne(p => p.Product)
               .WithMany(t => t.Reviews)
               .HasForeignKey(p => p.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}
