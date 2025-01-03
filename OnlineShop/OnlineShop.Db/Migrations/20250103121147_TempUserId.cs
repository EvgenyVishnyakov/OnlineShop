using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class TempUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("0e7cd7bb-61b0-4d50-8dcb-164b9695b1c8"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1704b64a-853c-4b55-9f6d-42d6eae63fb4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("423e982e-71f2-4412-ab1f-ea8b474fd17b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("54277135-f4c4-4d03-accc-c840cb418f3a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("69bf75fd-d680-43a3-b0cd-ab1bc972af13"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("6a0fbf55-41a3-4349-8c75-8149936fab09"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("6a148411-ed47-43f9-b162-1b74982524ae"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("6af89ae5-89a6-42a5-943a-82ca8321df0b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("70c17bff-0106-4200-bc2c-a06666f2be34"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("746b2e67-7d2b-45c4-b743-bfe3db08ed20"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("8a4852d8-3695-4fc3-a9d0-43f12ef40095"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("904a9644-4a48-40f3-8eef-8c3f7c9afef5"));

            migrationBuilder.AddColumn<Guid>(
                name: "TempUserId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("073e7ccc-b131-4d4d-97f5-035b0a45afe4"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("121dca91-ba9a-45a3-8467-adf3fa2a2600"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("2f78bb49-e5ab-454e-8a94-5aacb4f4fd79"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("365660df-0fe4-4bd7-9ff5-d49717a06dfe"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("482680e4-4ef0-41e3-b484-786e52bc5c8e"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("4c2480eb-4a25-4e28-9361-a5acde34d740"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("50dbf412-d344-4733-9d29-b8444d51e1d9"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("90f63a6c-4bb0-4ba6-9773-eae0af3c220e"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("950b050f-3097-4c2b-aa5b-2402cee6d4ef"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("e1ba5319-d50d-4f35-b818-608018ef371a"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("f68145f0-eb59-44d9-954b-f3b67197ef97"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("fddcec4e-5dc4-4c0c-aecd-66e70f69ef2d"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("073e7ccc-b131-4d4d-97f5-035b0a45afe4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("121dca91-ba9a-45a3-8467-adf3fa2a2600"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("2f78bb49-e5ab-454e-8a94-5aacb4f4fd79"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("365660df-0fe4-4bd7-9ff5-d49717a06dfe"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("482680e4-4ef0-41e3-b484-786e52bc5c8e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("4c2480eb-4a25-4e28-9361-a5acde34d740"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("50dbf412-d344-4733-9d29-b8444d51e1d9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("90f63a6c-4bb0-4ba6-9773-eae0af3c220e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("950b050f-3097-4c2b-aa5b-2402cee6d4ef"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("e1ba5319-d50d-4f35-b818-608018ef371a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("f68145f0-eb59-44d9-954b-f3b67197ef97"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("fddcec4e-5dc4-4c0c-aecd-66e70f69ef2d"));

            migrationBuilder.DropColumn(
                name: "TempUserId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0e7cd7bb-61b0-4d50-8dcb-164b9695b1c8"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("1704b64a-853c-4b55-9f6d-42d6eae63fb4"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("423e982e-71f2-4412-ab1f-ea8b474fd17b"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("54277135-f4c4-4d03-accc-c840cb418f3a"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("69bf75fd-d680-43a3-b0cd-ab1bc972af13"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("6a0fbf55-41a3-4349-8c75-8149936fab09"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("6a148411-ed47-43f9-b162-1b74982524ae"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("6af89ae5-89a6-42a5-943a-82ca8321df0b"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("70c17bff-0106-4200-bc2c-a06666f2be34"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("746b2e67-7d2b-45c4-b743-bfe3db08ed20"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("8a4852d8-3695-4fc3-a9d0-43f12ef40095"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("904a9644-4a48-40f3-8eef-8c3f7c9afef5"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") }
                });
        }
    }
}
