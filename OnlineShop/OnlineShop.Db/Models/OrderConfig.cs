using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Db.Models
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.OrderId);

            entityTypeBuilder.Property(e => e.Address)
                .IsRequired();

            entityTypeBuilder.Property(e => e.Email)
                .IsRequired();

            entityTypeBuilder.Property(e => e.Name)
                .IsRequired();

            entityTypeBuilder.Property(e => e.Phone)
                .IsRequired();

            entityTypeBuilder.Property(e => e.CreatedDateTime)
                .IsRequired();

            entityTypeBuilder.Property(e => e.TotalCost)
                .HasPrecision(18, 2);
        }
    }
}