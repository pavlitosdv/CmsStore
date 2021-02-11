using Microsoft.EntityFrameworkCore.Migrations;

namespace CmsStore.Migrations
{
    public partial class SeedCaategoryAndProductTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug", "Sorting" },
                values: new object[] { 1, "Fruits", "fruit", 0 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug", "Sorting" },
                values: new object[] { 2, "Clothes", "clothes", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Slug" },
                values: new object[,]
                {
                    { 1, 1, "Fruit product", "apples.jpg", "Apples", 3m, "Apples" },
                    { 2, 1, "Fruit product", "bananas.jpg", "Bananas", 2m, "Bananas" },
                    { 3, 1, "Fruit product", "grapes.jpg", "grapes", 1m, "grapes" },
                    { 4, 2, "shirt", "black shirt.jpg", "black shirt", 35m, "black-shirt" },
                    { 5, 2, "blue color", "blue shirt.jpg", "blue shirt", 38m, "blue-shirt" },
                    { 6, 2, "pink product", "pink shirt.jpg", "pink shirt", 55m, "pink-shirt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
