using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Data.Migrations
{
    public partial class CampaignGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignsGoal_Campaign_CampaignFkNavigationId",
                table: "CampaignsGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignsGoal_Goal_GoalFkNavigationId",
                table: "CampaignsGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampaignsGoal",
                table: "CampaignsGoal");

            migrationBuilder.RenameTable(
                name: "CampaignsGoal",
                newName: "CampaignGoal");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignsGoal_GoalFkNavigationId",
                table: "CampaignGoal",
                newName: "IX_CampaignGoal_GoalFkNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignsGoal_CampaignFkNavigationId",
                table: "CampaignGoal",
                newName: "IX_CampaignGoal_CampaignFkNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampaignGoal",
                table: "CampaignGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignGoal_Campaign_CampaignFkNavigationId",
                table: "CampaignGoal",
                column: "CampaignFkNavigationId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignGoal_Goal_GoalFkNavigationId",
                table: "CampaignGoal",
                column: "GoalFkNavigationId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignGoal_Campaign_CampaignFkNavigationId",
                table: "CampaignGoal");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignGoal_Goal_GoalFkNavigationId",
                table: "CampaignGoal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CampaignGoal",
                table: "CampaignGoal");

            migrationBuilder.RenameTable(
                name: "CampaignGoal",
                newName: "CampaignsGoal");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignGoal_GoalFkNavigationId",
                table: "CampaignsGoal",
                newName: "IX_CampaignsGoal_GoalFkNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_CampaignGoal_CampaignFkNavigationId",
                table: "CampaignsGoal",
                newName: "IX_CampaignsGoal_CampaignFkNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CampaignsGoal",
                table: "CampaignsGoal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignsGoal_Campaign_CampaignFkNavigationId",
                table: "CampaignsGoal",
                column: "CampaignFkNavigationId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignsGoal_Goal_GoalFkNavigationId",
                table: "CampaignsGoal",
                column: "GoalFkNavigationId",
                principalTable: "Goal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
