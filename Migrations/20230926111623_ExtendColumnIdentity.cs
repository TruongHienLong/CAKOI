using Microsoft.EntityFrameworkCore.Migrations;

namespace QL_BanHangManh_Thang.Migrations
{
    public partial class ExtendColumnIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TonKhos",
                keyColumn: "IdSPTonKho",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TonKhos",
                keyColumn: "IdSPTonKho",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "SanPhams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 1,
                column: "IdSPTonKho",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 2,
                column: "IdSPTonKho",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "SanPhams");

            migrationBuilder.InsertData(
                table: "TonKhos",
                columns: new[] { "IdSPTonKho", "SoLuong" },
                values: new object[] { 1, 20 });

            migrationBuilder.InsertData(
                table: "TonKhos",
                columns: new[] { "IdSPTonKho", "SoLuong" },
                values: new object[] { 2, 20 });

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 1,
                column: "IdSPTonKho",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SanPhams",
                keyColumn: "IdSanPham",
                keyValue: 2,
                column: "IdSPTonKho",
                value: 2);
        }
    }
}
