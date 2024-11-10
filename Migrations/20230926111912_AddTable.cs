using Microsoft.EntityFrameworkCore.Migrations;

namespace QL_BanHangManh_Thang.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 1,
                column: "SoLuong",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 2,
                column: "SoLuong",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 1,
                column: "SoLuong",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 2,
                column: "SoLuong",
                value: 0);
        }
    }
}
