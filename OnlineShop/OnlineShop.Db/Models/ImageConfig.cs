using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Db.Models
{
    internal class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.ImageId);

            entityTypeBuilder.Property(e => e.ImagesPath)
                .IsRequired();

            entityTypeBuilder.HasOne(p => p.Product)
                      .WithMany(i => i.Images)
                      .HasForeignKey(i => i.ProductId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            entityTypeBuilder.HasData(
            // Кухня
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2"))
            .WithImagePath("/Images/Кухня_Сормово.png")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2"))
            .WithImagePath("/Images/Шкаф.jpg")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2"))
            .WithImagePath("/Images/спальни.jpg")
            .Build(),
            // Шкафы
                 new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0"))
            .WithImagePath("/Images/Кухня_Сормово.png")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0"))
            .WithImagePath("/Images/Шкаф.jpg")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0"))
            .WithImagePath("/Images/спальни.jpg")
            .Build(),
                // Детская мебель
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c"))
            .WithImagePath("/Images/Кухня_Сормово.png")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c"))
            .WithImagePath("/Images/Шкаф.jpg")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c"))
            .WithImagePath("/Images/спальни.jpg")
            .Build(),

                // Спальни
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15"))
            .WithImagePath("/Images/Кухня_Сормово.png")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15"))
            .WithImagePath("/Images/Шкаф.jpg")
            .Build(),
                new ImageBuilder()
            .WithId(Guid.NewGuid())
            .WithProductId(new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15"))
            .WithImagePath("/Images/спальни.jpg")
            .Build()
        );
        }
    }
}