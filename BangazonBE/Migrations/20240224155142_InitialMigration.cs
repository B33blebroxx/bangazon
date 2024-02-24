using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonBE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ProfileImgUrl = table.Column<string>(type: "text", nullable: false),
                    IsSeller = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Smart TVs" },
                    { 2, "Gaming Accessories" },
                    { 3, "Headphones" },
                    { 4, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsComplete", "PaymentTypeId" },
                values: new object[,]
                {
                    { 1, 2, true, 3 },
                    { 2, 1, false, null },
                    { 3, 1, true, 2 },
                    { 4, 4, false, null },
                    { 5, 3, true, 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentName" },
                values: new object[,]
                {
                    { 1, "PayPal" },
                    { 2, "Debit" },
                    { 3, "Credit" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityAvailable", "SellerId" },
                values: new object[,]
                {
                    { 1, 1, "Super high def QLED display with crazy powerful processor for 8K upscaling.", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6535/6535209_sd.jpg;maxHeight=400;maxWidth=600", "Samsung Smart TV", 3999.99m, 10, 5 },
                    { 2, 2, "Memory foam seat, armrests, and headrest, adjustable lumbar support, and breatheable fabric.", "https://m.media-amazon.com/images/I/61t4mpabO+L._AC_UF894,1000_QL80_.jpg", "Gaming Chair", 449.99m, 7, 1 },
                    { 3, 2, "Bluetooth DualSense Edge controller for the Playstation 5.", "https://i5.walmartimages.com/seo/Sony-PS5-DualSense-Edge-Wireless-Controller_657e4493-944a-4782-9654-f8e024752c67.8319804d8bf7e5311004fecfb9f0e7f4.png?odnHeight=640&odnWidth=640&odnBg=FFFFFF", "Wireless PS5 Controller", 169.99m, 15, 1 },
                    { 4, 3, "High quality audio output, 6 hour battery life, full noise cancellation.", "https://m.media-amazon.com/images/I/51bRSWrEc7S._AC_UF1000,1000_QL80_.jpg", "Wireless Earbuds", 219.99m, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsSeller", "LastName", "ProfileImgUrl", "Uid", "UserName" },
                values: new object[,]
                {
                    { 1, "b33blebroxx@gmail.com", "Brandon", true, "Schnurbusch", "https://avatars.githubusercontent.com/u/134976580?v=4", "", "bschnurb" },
                    { 2, "sidestoriesLPOTL@gmail.com", "Henry", true, "Zebrowski", "https://m.media-amazon.com/images/M/MV5BMjE3MTE4NjU0NF5BMl5BanBnXkFtZTgwMDk5NzE5NzE@._V1_.jpg", "", "DrFanTasty" },
                    { 3, "brighterside@gmail.com", "Ed", true, "Larson", "https://m.media-amazon.com/images/M/MV5BNTIyYWI0ZDMtMTc3Mi00ZGFiLThjZDYtMGNmZDRjMWM0MDQ4XkEyXkFqcGdeQXVyMTI0OTEzNjY@._V1_.jpg", "", "Ham" },
                    { 4, "LPOTL@gmail.com", "Marcus", true, "Parks", "https://storage.googleapis.com/pkommunity/website/images/Host%20Headshots/marcus-parks.png", "", "DogMeat" },
                    { 5, "holdenatorsHo@gmail.com", "Holden", false, "McNeely", "https://pbs.twimg.com/profile_images/758335467431616512/RfoPP_jP_400x400.jpg", "", "LizardMan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
