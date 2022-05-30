using Microsoft.EntityFrameworkCore.Migrations;

namespace RockBand.Data.Migrations
{
    public partial class addmigrationCnerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Concert");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Concert",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
