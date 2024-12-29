using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ProductName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("0a8f352e-9cf1-4462-a945-4bd753487243"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("12a0e49c-2d78-4d54-b3f4-a035c6dffc1f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1320a827-f1f9-4adb-8d8c-6f8194ba642d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1475726a-8a86-44d1-b859-4711a488b474"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("15ec3818-e24b-499a-bd28-3eb6eafb000f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("24a23fca-5973-45e4-b830-f72e95bbb13d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("3945c344-13c8-4abb-b7e0-7310c3eb68eb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("714c686a-e78c-4463-a344-cbfbea46d313"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("7c765776-335c-4537-868b-6304b25046ec"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("a2293463-de3b-465a-ac6d-b74463c073eb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("e006c22a-a0ad-4637-970f-094ccfc04455"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("fbc9367c-874a-4762-a382-1d63921cff50"));

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("01682283-ab9b-4764-92ed-06b37fb1ac5e"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("06d6b1c9-7db2-4f30-8dd7-83936569b320"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("1562abe0-954c-4d75-9cea-96a1d612a6b2"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("2a030137-7d62-4d99-928f-a642ffdcad49"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("2a66f708-e543-4e97-abfd-ca0638f2bc7f"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("5055c7cd-e800-43cb-817c-ae88e52cd682"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("5fca0503-5d8d-414a-a215-d618f00ae674"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("884ccd89-bf59-4182-8118-c164608de661"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("ad00c0ff-52db-4db5-9480-c817063ba911"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("b747d8df-42dd-4af4-9575-a0b941dc1983"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("e3364067-3d65-4476-b0ba-546e3ea298d3"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("ebf4a7c6-7339-4e9d-aeef-df3adbd846fe"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("01682283-ab9b-4764-92ed-06b37fb1ac5e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("06d6b1c9-7db2-4f30-8dd7-83936569b320"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1562abe0-954c-4d75-9cea-96a1d612a6b2"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("2a030137-7d62-4d99-928f-a642ffdcad49"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("2a66f708-e543-4e97-abfd-ca0638f2bc7f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5055c7cd-e800-43cb-817c-ae88e52cd682"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("5fca0503-5d8d-414a-a215-d618f00ae674"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("884ccd89-bf59-4182-8118-c164608de661"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("ad00c0ff-52db-4db5-9480-c817063ba911"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("b747d8df-42dd-4af4-9575-a0b941dc1983"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("e3364067-3d65-4476-b0ba-546e3ea298d3"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("ebf4a7c6-7339-4e9d-aeef-df3adbd846fe"));

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("0a8f352e-9cf1-4462-a945-4bd753487243"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("12a0e49c-2d78-4d54-b3f4-a035c6dffc1f"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("1320a827-f1f9-4adb-8d8c-6f8194ba642d"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("1475726a-8a86-44d1-b859-4711a488b474"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("15ec3818-e24b-499a-bd28-3eb6eafb000f"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("24a23fca-5973-45e4-b830-f72e95bbb13d"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("3945c344-13c8-4abb-b7e0-7310c3eb68eb"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("714c686a-e78c-4463-a344-cbfbea46d313"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("7c765776-335c-4537-868b-6304b25046ec"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("a2293463-de3b-465a-ac6d-b74463c073eb"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("e006c22a-a0ad-4637-970f-094ccfc04455"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("fbc9367c-874a-4762-a382-1d63921cff50"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") }
                });
        }
    }
}
