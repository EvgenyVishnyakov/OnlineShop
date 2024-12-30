using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Db.Models;

public class RatingConfig : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> entityTypeBuilder)
    {
        entityTypeBuilder.HasKey(e => e.Id);

        entityTypeBuilder.Property(e => e.ProductId)
            .IsRequired();

        entityTypeBuilder.Property(e => e.Grade)
             .IsRequired();
    }
}