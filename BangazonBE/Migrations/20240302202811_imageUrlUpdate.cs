using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangazonBE.Migrations
{
    public partial class imageUrlUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://c8.alamy.com/comp/D3C9R8/smart-tv-with-samsung-apps-and-web-browser-D3C9R8.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRi83YREwGa67Zs-_OBjT_EjTitdaxkncb-ozkmrPvNbeaO-q27LOVqPB5fYBfPBBxuLk&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.shutterstock.com/image-vector/tokyo-2021-sony-play-station-260nw-2085889891.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRW0lOAR5jVc0pZqExthLSMqvjPFuwxx9CBzQ&usqp=CAU", "Wireless Headphones" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.shutterstock.com/image-photo/young-woman-sitting-on-sofa-260nw-767180002.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6535/6535209_sd.jpg;maxHeight=400;maxWidth=600");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61t4mpabO+L._AC_UF894,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i5.walmartimages.com/seo/Sony-PS5-DualSense-Edge-Wireless-Controller_657e4493-944a-4782-9654-f8e024752c67.8319804d8bf7e5311004fecfb9f0e7f4.png?odnHeight=640&odnWidth=640&odnBg=FFFFFF");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "https://m.media-amazon.com/images/I/51bRSWrEc7S._AC_UF1000,1000_QL80_.jpg", "Wireless Earbuds" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://target.scene7.com/is/image/Target/GUEST_eaedb9ad-9979-491e-9ab6-a820f39ae91e?wid=488&hei=488&fmt=pjpeg");
        }
    }
}
