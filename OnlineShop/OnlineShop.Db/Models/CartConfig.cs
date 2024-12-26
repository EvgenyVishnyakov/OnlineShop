using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Db.Models
{
    internal class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.CartId);

            entityTypeBuilder.Property(e => e.IsActive)
                .IsRequired();
        }
    }
}

