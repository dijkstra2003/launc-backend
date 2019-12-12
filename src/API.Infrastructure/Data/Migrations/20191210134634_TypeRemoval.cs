using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Infrastructure.Data.Migrations
{
    public partial class TypeRemoval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_CampaignType_CampaignTypeNavigationId",
                table: "Campaign");

            migrationBuilder.DropTable(
                name: "CampaignType");

            migrationBuilder.DropIndex(
                name: "IX_Campaign_CampaignTypeNavigationId",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "CampaignType",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "CampaignTypeNavigationId",
                table: "Campaign");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignType",
                table: "Campaign",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CampaignTypeNavigationId",
                table: "Campaign",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampaignType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    TypeDescription = table.Column<string>(type: "text", nullable: true),
                    TypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_CampaignTypeNavigationId",
                table: "Campaign",
                column: "CampaignTypeNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_CampaignType_CampaignTypeNavigationId",
                table: "Campaign",
                column: "CampaignTypeNavigationId",
                principalTable: "CampaignType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
