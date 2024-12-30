using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class RatingInProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("029b75c7-013a-49b1-8d01-b0ef63786d03"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1fa293c1-a67a-43c2-8946-b0e9a38ee272"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("26232171-0b7b-4976-8167-ed2d078f3cb6"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("336477eb-47f6-4051-b89d-98ce67a395d1"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("3576197d-c1a6-47eb-9282-58c3181a701c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("3c07db9e-723a-42c2-9787-bc15a4dc47ee"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("493ad949-8e2c-4a9f-8398-d6b17346e4a5"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("715f2c61-dc85-4588-a3ed-0f3b780a4ecd"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("95c15a46-7562-49f7-9040-960c5870b104"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("9e3e53a5-b9d0-4a10-9dd6-c33bb7ef7673"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b06c753e-85bb-44de-81a0-9f9337dba470"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("d1ac6f4b-9f7b-4319-9890-7080cd244301"));

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "Ratings",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(3)",
                oldPrecision: 3,
                oldScale: 2);

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(3)",
                oldPrecision: 3,
                oldScale: 2);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "Ratings",
                type: "float(3)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "Products",
                type: "float(3)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("029b75c7-013a-49b1-8d01-b0ef63786d03"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("1fa293c1-a67a-43c2-8946-b0e9a38ee272"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("26232171-0b7b-4976-8167-ed2d078f3cb6"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("336477eb-47f6-4051-b89d-98ce67a395d1"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("3576197d-c1a6-47eb-9282-58c3181a701c"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("3c07db9e-723a-42c2-9787-bc15a4dc47ee"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("493ad949-8e2c-4a9f-8398-d6b17346e4a5"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("715f2c61-dc85-4588-a3ed-0f3b780a4ecd"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("95c15a46-7562-49f7-9040-960c5870b104"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("9e3e53a5-b9d0-4a10-9dd6-c33bb7ef7673"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("b06c753e-85bb-44de-81a0-9f9337dba470"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("d1ac6f4b-9f7b-4319-9890-7080cd244301"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") }
                });
        }
    }
}
