using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UserId",
                table: "Carts");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0567df90-af34-4894-87f3-eef374434f2f"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("19c72c84-9771-4375-9dd3-795fdb1ee0f8"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("1a66e5b5-51d3-403d-8f52-2e2348605323"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("40a164cd-0b40-4aab-acb8-fb47ebce8e9f"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("547d8350-d48e-405f-a536-4bcac599e6e9"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("5b612173-e20a-4920-9344-b2c4bf0279e6"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("6569c4ed-4239-4cc2-9f61-af2ed5160975"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("755ad40c-f487-48a6-970e-bd312459dcc5"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("8dbdeb4e-c194-4f5c-a2ba-3b0b2f9c0c22"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("b24dcfc3-4712-486c-8ee0-02d9d0a21958"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("b33ec5d4-b2db-43dd-994d-b02f99f3d377"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("e13e96f2-f8f5-4a2a-9ba9-4598beb4fdb7"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("0567df90-af34-4894-87f3-eef374434f2f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("19c72c84-9771-4375-9dd3-795fdb1ee0f8"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1a66e5b5-51d3-403d-8f52-2e2348605323"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("40a164cd-0b40-4aab-acb8-fb47ebce8e9f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("547d8350-d48e-405f-a536-4bcac599e6e9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5b612173-e20a-4920-9344-b2c4bf0279e6"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("6569c4ed-4239-4cc2-9f61-af2ed5160975"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("755ad40c-f487-48a6-970e-bd312459dcc5"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("8dbdeb4e-c194-4f5c-a2ba-3b0b2f9c0c22"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b24dcfc3-4712-486c-8ee0-02d9d0a21958"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b33ec5d4-b2db-43dd-994d-b02f99f3d377"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("e13e96f2-f8f5-4a2a-9ba9-4598beb4fdb7"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
