using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class TransionUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("0412d403-fd9b-41cf-b53f-667067c0b64e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1e8d7fa2-7c32-4867-bf3b-6cd96c300c18"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("2f225b37-544a-41ec-bca1-50205bab4a96"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("30bfcbc9-146c-4fd7-9c16-a8327ba81ee9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("317dfe8e-675f-4117-aaf5-6dae6065cc58"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("388050c3-2aff-4bb9-a26f-78224f56a61e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("519485c3-a683-4fad-b4f5-69aba1a7d1ce"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5feaea1c-54df-443c-a5c5-f65e961d5bcb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("c647a6ed-ba9c-402a-94e5-041a1f765639"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("d5d47357-857a-4a89-8013-1ee97b49f5d4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("d9fe3ccc-bbc8-4950-9d8e-4a7cf8e2eb67"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("e502a520-faa7-4d8a-accc-f2b3ea82e326"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comparisons",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "TempUserId",
                table: "AspNetUsers",
                newName: "TransitionUserId");

            migrationBuilder.AddColumn<string>(
                name: "TransitionUserId",
                table: "Comparisons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("2b28d03d-137a-48c2-87c1-827bd6b9033c"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("4070684b-471b-4d53-81ec-d2c3a0d0f240"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("50424fd9-7b44-4db1-961a-c5c7b3f860ee"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("5dd51e8e-492c-47c5-b5a6-8f879b02ba1c"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("663b9777-9640-4eba-a7a4-99b021fe5cf3"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("7eaa74b7-721e-4dee-8782-64d20871da2e"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("b2b03b2c-706d-41af-a9aa-9b0b9c4adfff"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("b93952b4-620a-4f22-8e94-3d4bbd039553"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("b94c1d62-0788-4737-b92c-3036b9443927"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("c7f36756-f928-4ce9-8ec6-93ebe91178c0"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("d903720a-d6bc-4f42-b427-57785e70b7bc"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("dee44930-dce0-411b-80a7-72b550a01319"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("2b28d03d-137a-48c2-87c1-827bd6b9033c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("4070684b-471b-4d53-81ec-d2c3a0d0f240"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("50424fd9-7b44-4db1-961a-c5c7b3f860ee"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5dd51e8e-492c-47c5-b5a6-8f879b02ba1c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("663b9777-9640-4eba-a7a4-99b021fe5cf3"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("7eaa74b7-721e-4dee-8782-64d20871da2e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b2b03b2c-706d-41af-a9aa-9b0b9c4adfff"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b93952b4-620a-4f22-8e94-3d4bbd039553"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b94c1d62-0788-4737-b92c-3036b9443927"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("c7f36756-f928-4ce9-8ec6-93ebe91178c0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("d903720a-d6bc-4f42-b427-57785e70b7bc"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("dee44930-dce0-411b-80a7-72b550a01319"));

            migrationBuilder.DropColumn(
                name: "TransitionUserId",
                table: "Comparisons");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Comparisons",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "TransitionUserId",
                table: "AspNetUsers",
                newName: "TempUserId");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0412d403-fd9b-41cf-b53f-667067c0b64e"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("1e8d7fa2-7c32-4867-bf3b-6cd96c300c18"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("2f225b37-544a-41ec-bca1-50205bab4a96"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("30bfcbc9-146c-4fd7-9c16-a8327ba81ee9"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("317dfe8e-675f-4117-aaf5-6dae6065cc58"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("388050c3-2aff-4bb9-a26f-78224f56a61e"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("519485c3-a683-4fad-b4f5-69aba1a7d1ce"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("5feaea1c-54df-443c-a5c5-f65e961d5bcb"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("c647a6ed-ba9c-402a-94e5-041a1f765639"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("d5d47357-857a-4a89-8013-1ee97b49f5d4"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("d9fe3ccc-bbc8-4950-9d8e-4a7cf8e2eb67"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("e502a520-faa7-4d8a-accc-f2b3ea82e326"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") }
                });
        }
    }
}
