using Microsoft.EntityFrameworkCore.Migrations;

namespace QL_BanHangManh_Thang.Migrations
{
    public partial class AddTableToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_MauSac_IdMauSac",
                table: "SanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac");

            migrationBuilder.RenameTable(
                name: "MauSac",
                newName: "MauSacs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauSacs",
                table: "MauSacs",
                column: "IdMauSac");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_MauSacs_IdMauSac",
                table: "SanPhams",
                column: "IdMauSac",
                principalTable: "MauSacs",
                principalColumn: "IdMauSac",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_MauSacs_IdMauSac",
                table: "SanPhams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MauSacs",
                table: "MauSacs");

            migrationBuilder.RenameTable(
                name: "MauSacs",
                newName: "MauSac");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MauSac",
                table: "MauSac",
                column: "IdMauSac");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_MauSac_IdMauSac",
                table: "SanPhams",
                column: "IdMauSac",
                principalTable: "MauSac",
                principalColumn: "IdMauSac",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
