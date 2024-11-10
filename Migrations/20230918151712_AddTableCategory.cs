using Microsoft.EntityFrameworkCore.Migrations;

namespace QL_BanHangManh_Thang.Migrations
{
    public partial class AddTableCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucSPs",
                columns: table => new
                {
                    IdDanhMucSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDanhMucSP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucSPs", x => x.IdDanhMucSP);
                });

            migrationBuilder.CreateTable(
                name: "MauSac",
                columns: table => new
                {
                    IdMauSac = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSac", x => x.IdMauSac);
                });

            migrationBuilder.CreateTable(
                name: "TonKhos",
                columns: table => new
                {
                    IdSPTonKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TonKhos", x => x.IdSPTonKho);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSPs",
                columns: table => new
                {
                    IdLoaiSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDanhMucSP = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSPs", x => x.IdLoaiSP);
                    table.ForeignKey(
                        name: "FK_LoaiSPs_DanhMucSPs_IdDanhMucSP",
                        column: x => x.IdDanhMucSP,
                        principalTable: "DanhMucSPs",
                        principalColumn: "IdDanhMucSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    IdSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false),
                    IdLoaicSP = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdMauSac = table.Column<int>(type: "int", nullable: false),
                    IdSPTonKho = table.Column<int>(type: "int", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.IdSanPham);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSPs_IdLoaicSP",
                        column: x => x.IdLoaicSP,
                        principalTable: "LoaiSPs",
                        principalColumn: "IdLoaiSP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_MauSac_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSac",
                        principalColumn: "IdMauSac",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_TonKhos_IdSPTonKho",
                        column: x => x.IdSPTonKho,
                        principalTable: "TonKhos",
                        principalColumn: "IdSPTonKho",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DanhMucSPs",
                columns: new[] { "IdDanhMucSP", "TenDanhMucSP" },
                values: new object[,]
                {
                    { "DT", "Điện thoại" },
                    { "GM", "Game" },
                    { "PK", "Phụ Kiện" },
                    { "MT", "Máy Tính" }
                });

            migrationBuilder.InsertData(
                table: "MauSac",
                columns: new[] { "IdMauSac", "TenMau" },
                values: new object[,]
                {
                    { 1, "Đỏ" },
                    { 2, "Xanh" }
                });

            migrationBuilder.InsertData(
                table: "TonKhos",
                columns: new[] { "IdSPTonKho", "SoLuong" },
                values: new object[,]
                {
                    { 1, 20 },
                    { 2, 20 }
                });

            migrationBuilder.InsertData(
                table: "LoaiSPs",
                columns: new[] { "IdLoaiSP", "IdDanhMucSP", "TenLoaiSP" },
                values: new object[,]
                {
                    { "IP", "DT", "Iphone" },
                    { "Ard", "DT", "Android" },
                    { "MI", "DT", "XiaoMi" },
                    { "MTB", "DT", "Máy tính bảng" },
                    { "PS", "GM", "Máy chơi game PlayStayion" },
                    { "NTD", "GM", "Máy chơi game NinTenDo" },
                    { "CTR", "GM", "Máy chơi game cầm tay" },
                    { "TN", "PK", "Tai nghe" },
                    { "BP", "PK", "Bàn Phím" },
                    { "CH", "PK", "Chuột" },
                    { "DG", "PK", "Đĩa Game" },
                    { "LT", "MT", "LapTop" },
                    { "PC", "MT", "Máy tính bàn" }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "IdSanPham", "Anh", "Gia", "IdLoaicSP", "IdMauSac", "IdSPTonKho", "MoTa", "TenSanPham" },
                values: new object[] { 1, null, 300.0, "IP", 1, 1, null, "Iphone 7" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "IdSanPham", "Anh", "Gia", "IdLoaicSP", "IdMauSac", "IdSPTonKho", "MoTa", "TenSanPham" },
                values: new object[] { 2, null, 300.0, "IP", 1, 2, null, "Iphone 8" });

            migrationBuilder.CreateIndex(
                name: "IX_LoaiSPs_IdDanhMucSP",
                table: "LoaiSPs",
                column: "IdDanhMucSP");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdLoaicSP",
                table: "SanPhams",
                column: "IdLoaicSP");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdMauSac",
                table: "SanPhams",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_IdSPTonKho",
                table: "SanPhams",
                column: "IdSPTonKho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "LoaiSPs");

            migrationBuilder.DropTable(
                name: "MauSac");

            migrationBuilder.DropTable(
                name: "TonKhos");

            migrationBuilder.DropTable(
                name: "DanhMucSPs");
        }
    }
}
