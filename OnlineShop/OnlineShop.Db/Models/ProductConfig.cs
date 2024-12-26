using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Db.Models
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            var kitchenId = new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2");
            var bedroomId = new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0");
            var childremFurnitureId = new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c");
            var furnitureId = new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15");

            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property(e => e.Name)
                .HasMaxLength(20)
                    .IsRequired();

            entityTypeBuilder.Property(e => e.Cost)
                .HasPrecision(9, 2)
                    .IsRequired();

            entityTypeBuilder.Property(e => e.Category)
                    .IsRequired();

            entityTypeBuilder.Property(e => e.Description)
                .HasMaxLength(130)
                .IsRequired();

            entityTypeBuilder.HasMany(p => p.Images)
                      .WithOne(i => i.Product)
                      .HasForeignKey(i => i.ProductId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            entityTypeBuilder.HasData(
                new ProductBuilder()
            .WithId(kitchenId)
            .WithName("Мария")
            .WithCost(127900)
            .WithDescription("Авторское удобство для каждодневного использования")
            .WithCategory("Кухни")
            .Build(),

                new ProductBuilder()
            .WithId(furnitureId)
            .WithName("Венге")
            .WithCost(49900)
            .WithDescription("Уникальное удобство хранения Ваших вещей")
            .WithCategory("Шкафы")
            .Build(),

                new ProductBuilder()
            .WithId(childremFurnitureId)
            .WithName("Счастье")
            .WithCost(179900)
            .WithDescription("Уютная обстановка для детей")
            .WithCategory("Детская мебель")
            .Build(),

                new ProductBuilder()
            .WithId(bedroomId)
            .WithName("Пушка")
            .WithCost(99900)
            .WithDescription("Комфорт Вашего отдыха")
            .WithCategory("Спальни")
            .Build()
   );
        }
    }
}