using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Data.Migrations
{
    public partial class OneGoalForCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalId",
                table: "Campaign",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_GoalId",
                table: "Campaign",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Goal_GoalId",
                table: "Campaign",
                column: "GoalId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Goal_GoalId",
                table: "Campaign");

            migrationBuilder.DropIndex(
                name: "IX_Campaign_GoalId",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Campaign");
        }
    }
}
