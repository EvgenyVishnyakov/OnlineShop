using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddTransitionUserIdBYFavourite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("126f9d16-fb88-49b2-9cd9-9b50218c3653"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1caeaee5-6346-4a3d-a43e-027d96f9c02f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("1fc5bcef-3a77-46fb-ae5d-1b4480da1e80"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("36c9c044-4328-4452-90f0-a3f130889917"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("48c10c91-d227-4d1b-a827-c24297a8610e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("8980e49f-bb2b-48de-9944-eb22a72ed14a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("8f0faff0-c817-4043-b9fe-26c83dfd9b9a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("96651a47-553f-4188-aa72-9b3545555dd2"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("cc9f31ee-9d82-4df8-9708-e36b9d3638ac"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("cd850076-1427-4be3-a81e-cfcd723561c6"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("d83399a1-44e0-49b2-8f0e-01e48b659cba"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: new Guid("dcf77c4e-d784-4c9b-b4bd-d89d90e3253d"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Favourites",
                newName: "TransitionUserId");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Favourites",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Favourites");

            migrationBuilder.RenameColumn(
                name: "TransitionUserId",
                table: "Favourites",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImagesPath", "ProductId" },
                values: new object[,]
                {
                    { new Guid("126f9d16-fb88-49b2-9cd9-9b50218c3653"), "/Images/Кухня_Сормово.png", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("1caeaee5-6346-4a3d-a43e-027d96f9c02f"), "/Images/Кухня_Сормово.png", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("1fc5bcef-3a77-46fb-ae5d-1b4480da1e80"), "/Images/спальни.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("36c9c044-4328-4452-90f0-a3f130889917"), "/Images/Кухня_Сормово.png", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("48c10c91-d227-4d1b-a827-c24297a8610e"), "/Images/спальни.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") },
                    { new Guid("8980e49f-bb2b-48de-9944-eb22a72ed14a"), "/Images/Кухня_Сормово.png", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("8f0faff0-c817-4043-b9fe-26c83dfd9b9a"), "/Images/спальни.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("96651a47-553f-4188-aa72-9b3545555dd2"), "/Images/спальни.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("cc9f31ee-9d82-4df8-9708-e36b9d3638ac"), "/Images/Шкаф.jpg", new Guid("734b060e-7385-4c35-bfad-2187c5d8fd6c") },
                    { new Guid("cd850076-1427-4be3-a81e-cfcd723561c6"), "/Images/Шкаф.jpg", new Guid("68e896f8-c272-4b92-b52d-10d83e6452a2") },
                    { new Guid("d83399a1-44e0-49b2-8f0e-01e48b659cba"), "/Images/Шкаф.jpg", new Guid("86e210d8-3e55-4887-a957-55fa04bc7fc0") },
                    { new Guid("dcf77c4e-d784-4c9b-b4bd-d89d90e3253d"), "/Images/Шкаф.jpg", new Guid("5a6429bd-cc54-4252-a6ea-e370fcdada15") }
                });
        }
    }
}
