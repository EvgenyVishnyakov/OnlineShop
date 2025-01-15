using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1d9b8692-74a4-4b5d-8db4-40ea1976e5b6"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("3cc2692b-ed03-4a64-98b6-a89a0b76d14b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("4a1493e5-8f6b-4913-abb3-501aa4c45aab"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("4a3bbf96-eb2e-4dda-a7c9-9afb14fe6351"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("4a7b2ece-5706-4d2e-804b-fedea140964f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5ad7bb8a-e78b-40c2-944b-daf2b16f8bf3"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("60f6280a-b32e-4fec-8887-24f9f2116e47"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("635a9067-6472-4efa-9438-a742b02a2bc4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("94b8cdb9-fe8f-4e4e-afa5-b47fb70197ad"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("bb395983-de55-4bec-b4d7-0969888f7d63"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("c5ae8c47-024e-4037-badf-1bffef1dffca"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("de8c4cb1-a702-4fb0-a09c-e5ca2d35eddb"));

            migrationBuilder.AddColumn<string>(
                name: "TransitionUserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("02c84637-bf59-4a09-9459-5bf36ec1e9a2"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("5888f3a7-7bdf-42e1-b4a9-618d4e7749f3"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("5e7c3377-b71c-4f29-a7ec-f400dd5fd669"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("6790efc8-3405-47b2-b23a-0b67413ed2ae"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("80df4cca-a0fa-499c-ac1d-9e1ff54a6270"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("99cce320-ef0f-42cd-98bc-e34f6c51f949"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("9a896e85-5fa8-4d9f-a247-ce22a5ed40dc"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("a60d2d0f-1eaa-4d6a-9225-88faa433f890"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("affad030-ef73-45a5-99bc-96463c859450"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("b4a68e60-c2af-4d2f-8083-75729c9d1c1d"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("ea1ff32f-90fe-4520-8762-1e19030fa899"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("ec833ff1-f4cd-4592-9b54-d3de4fe929ee"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("02c84637-bf59-4a09-9459-5bf36ec1e9a2"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5888f3a7-7bdf-42e1-b4a9-618d4e7749f3"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5e7c3377-b71c-4f29-a7ec-f400dd5fd669"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("6790efc8-3405-47b2-b23a-0b67413ed2ae"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("80df4cca-a0fa-499c-ac1d-9e1ff54a6270"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("99cce320-ef0f-42cd-98bc-e34f6c51f949"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("9a896e85-5fa8-4d9f-a247-ce22a5ed40dc"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("a60d2d0f-1eaa-4d6a-9225-88faa433f890"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("affad030-ef73-45a5-99bc-96463c859450"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b4a68e60-c2af-4d2f-8083-75729c9d1c1d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("ea1ff32f-90fe-4520-8762-1e19030fa899"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("ec833ff1-f4cd-4592-9b54-d3de4fe929ee"));

            migrationBuilder.DropColumn(
                name: "TransitionUserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Carts");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("1d9b8692-74a4-4b5d-8db4-40ea1976e5b6"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("3cc2692b-ed03-4a64-98b6-a89a0b76d14b"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("4a1493e5-8f6b-4913-abb3-501aa4c45aab"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("4a3bbf96-eb2e-4dda-a7c9-9afb14fe6351"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("4a7b2ece-5706-4d2e-804b-fedea140964f"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("5ad7bb8a-e78b-40c2-944b-daf2b16f8bf3"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("60f6280a-b32e-4fec-8887-24f9f2116e47"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("635a9067-6472-4efa-9438-a742b02a2bc4"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("94b8cdb9-fe8f-4e4e-afa5-b47fb70197ad"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("bb395983-de55-4bec-b4d7-0969888f7d63"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("c5ae8c47-024e-4037-badf-1bffef1dffca"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("de8c4cb1-a702-4fb0-a09c-e5ca2d35eddb"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") }
                });
        }
    }
}
