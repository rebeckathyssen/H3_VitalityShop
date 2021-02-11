using Microsoft.EntityFrameworkCore.Migrations;

namespace VitalityShop.Infrastructure.Migrations
{
    public partial class changedconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "ZipCodes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_CityName",
                table: "ZipCodes",
                column: "CityName",
                unique: true,
                filter: "[CityName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_ZipCode",
                table: "ZipCodes",
                column: "ZipCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ZipCodes_CityName",
                table: "ZipCodes");

            migrationBuilder.DropIndex(
                name: "IX_ZipCodes_ZipCode",
                table: "ZipCodes");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "ZipCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
