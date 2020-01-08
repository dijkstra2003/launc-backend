using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Data.Migrations
{
    public partial class MollieId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MollieId",
                table: "MollieResponse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MollieId",
                table: "MollieResponse");
        }
    }
}
