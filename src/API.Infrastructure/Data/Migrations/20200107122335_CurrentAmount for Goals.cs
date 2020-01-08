using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Data.Migrations
{
    public partial class CurrentAmountforGoals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentAmount",
                table: "Subgoal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentAmount",
                table: "Goal",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAmount",
                table: "Subgoal");

            migrationBuilder.DropColumn(
                name: "CurrentAmount",
                table: "Goal");
        }
    }
}
    